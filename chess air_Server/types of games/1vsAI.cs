using chess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace chess_air_Server.types_of_games
{
    internal class _1vsAI : types_of_games.Game
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="Mclient1"></param>
        public _1vsAI(ManageClient Mclient1)
        {
            this.Mclient1 = Mclient1;

            // send all of the initial information so the players coud start playing
            if (this.rn.Next(2) == 0)
            {
                Mclient1.SendMessage("###start_game###" + Mclient1.get_nick() + "&" + "AI" + "&" + "white");
                Mclient1.my_turn = true;
                this.Mclient1white = true;
            }
            else
            {
                Mclient1.SendMessage("###start_game###" + Mclient1.get_nick() + "&" + "AI" + "&" + "black");
                Mclient1.my_turn = false;
                this.Mclient1white = false;
                AI_make_move();
                Mclient1.my_turn = true;
            }
            Console.WriteLine("new game: " + Mclient1.get_nick() + " VS AI");
        }

        /// <summary>
        /// function to check messages related to the game
        /// </summary>
        /// <param name="messageReceived"></param>
        public override void GameMessageHandler(string messageReceived) // recieve message only from the client
        {
            if (messageReceived.StartsWith("###move###")) //the client propose to make a move
            { // XYXY format. the first XY is the start position and the second XY is the end position.
                Move move = base.find_legal_move(messageReceived);
                if (move.startsquare != -1) //found a ligal move
                {
                    base.send_move(Mclient1, messageReceived, move.edgecase);//send the white clients that the move has been made
                    base.moves += messageReceived.Remove(0, 10) + "#" + move.edgecase + "-";
                    this.chessboard.Manualy_makemove(move);
                    Console.WriteLine(this.Mclient1.get_nick() + " VS AI\n" + this.chessboard.ToString());
                    //check if the game ended:
                    //if the new players turn cant move anymore
                    if (!check_if_game_ended("you won")) //the AI cant move at all.
                    {
                        AI_make_move();
                        check_if_game_ended("you lost");
                    }
                }
            }
            else if (messageReceived.StartsWith("###pot_move###"))
            { //message: ###pot_move###XY
                send_pot_moves(messageReceived, this.Mclient1);
            }
            else if (messageReceived.Equals("###resignation###"))
                Mclient1.endgame("you resigned");
        }

        /// <summary>
        /// function that handle resignation
        /// </summary>
        /// <param name="resigned_client"></param>
        public override void ResignationHandler(ManageClient resigned_client)
        {
            resigned_client.endgame("you resigned");
        }

        /// <summary>
        /// choose the ai move and send it to the player
        /// </summary>
        private void AI_make_move()
        {
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            Move aimove = this.chessboard.generator.Choose_move(depth: 4, for_white_player: !Mclient1white);
            stopwatch.Stop();
            Console.WriteLine(this.Mclient1.get_nick() + " VS AI, found a move({0}) in {1} seconds, static evaluation: {2}",
                aimove.Print_in_notation(), (float)stopwatch.ElapsedMilliseconds / 1000, this.chessboard.Evaluate());
            this.chessboard.Manualy_makemove(aimove);
            Console.WriteLine(this.chessboard.ToString());
            if ((float)stopwatch.ElapsedMilliseconds < 250)//AI took less than 100 miliseconds to make a move
                Thread.Sleep(250);//wait until 100 miliseconds have passed

            string move = ""+Chessboard.Get_i_pos(aimove.startsquare) + Chessboard.Get_j_pos(aimove.startsquare) 
                + Chessboard.Get_i_pos(aimove.endsquare) + Chessboard.Get_j_pos(aimove.endsquare);

            base.send_move(Mclient1, "###move###" + move, aimove.edgecase);//send the white clients that the move has been made
            base.moves += move + "#" + aimove.edgecase + "-";
        }

        /// <summary>
        /// check if game ended and act accordingly
        /// </summary>
        /// <param name="if_checkmate_message"></param>
        /// <returns></returns>
        private bool check_if_game_ended(string if_checkmate_message)
        {
            if (this.chessboard.generator.Generate_all_legal_moves().Count == 0)//the AI won
            {
                if (this.chessboard.Current_player_king_in_check()) //checkmate
                {
                    Mclient1.endgame(if_checkmate_message);
                }
                else //draw
                {
                    Mclient1.endgame("draw");
                }
                if (Mclient1white)
                    base.savegame(white_player_id: this.Mclient1.client_id);
                else
                    base.savegame(black_player_id: this.Mclient1.client_id);
                return true;
            }
            return false;
        }
    }
}
