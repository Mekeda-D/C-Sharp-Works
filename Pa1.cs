using System;
using static System.Console;

namespace PA1
{
	static class Isolation
	{
		// board for Isolation game
		// 0 is an empty cell
		// 1 is an A 
		// 2 is an B
		static int[,] board = new int[8,6]
		{
			{0,0,0,0,0,0},
			{0,0,0,0,0,0},
			{0,0,0,0,0,0},
			{0,0,0,0,0,0},
			{0,0,0,0,0,0},
			{0,0,0,0,0,0},
			{0,0,0,0,0,0},
			{0,0,0,0,0,0}
		};
			
		// Method checks if the space is free to move to
		// If move is possible, returns true. 
		// If move is not possible, return false
		
		public static bool Is_space_free(int row, int col)
		{
			if (board[row, col]==0)
			{
				return true;
			}
			else 
			{
				return false;
			}
			
		}
		
		// Method for adding Symbol to the board.
		// symbol is 1 for A, 2 for B
		
		public static void AddSymbol(int row, int col, int playerSymbol)
		{
			board[row, col]= playerSymbol;
		}
		
		// Method for removing Symbol from the board.
		// If move is possible, returns true. 
		// If move is not possible, return false
		// symbol is 1 for A, 2 for B
		
		public static bool RemoveSymbol(int row, int col)
		{
			if (board[row, col]!=0)
			{
				board[row, col]= 0;
				return true;
			}
			else 
			{
				return false;
			}
			
		}
		
		// Method for adding a block to the board to prevent player from moving to that tile. 
		// symbol is 3 is for a block
		
		public static void AddBlock(int row, int col, int playerSymbol)
		{
			board[row, col]= playerSymbol;
		}
		
		// Method to check if a player is removing the starting platform. 
		public static bool Check_if_user_is_removing_starting_platform(int row, int col)
		{
			if ((row == 0 && col == 3) || (row == 7 && col == 2))
			{
				return false;
			}
			else 
			{
				return true;
			}
			
		}
		
		// The following two methods check if the tile one space in any direction from the current position of player
		// (diagonally, sideways, forward and backward) is free. Method is used to determine the winner
		public static bool CheckAvailableSpaces(int row, int col)
		{
			if (row == 0 && col == 0)
			{
				if ((board[row, col+1] == 0)|| (board[row+1, col+1] == 0)|| (board[row+1, col] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if ((row == 0 && col == 1)||(row == 0 && col == 2)||(row == 0 && col == 3)||(row == 0 && col == 4))
			{
				if ((board[row, col+1] == 0)|| (board[row+1, col+1] == 0)|| (board[row+1, col] == 0)||(board[row+1, col-1] == 0)|| (board[row, col-1] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if (row == 0 && col == 5)
			{
				if ((board[row+1, col] == 0)||(board[row+1, col-1] == 0)|| (board[row, col-1] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if ((row == 1 && col ==0)||(row == 2 && col ==0)||(row == 3 && col ==0)||(row == 4 && col ==0)||(row == 5 && col ==0)||(row == 6 && col ==0))
			{
				if ((board[row-1, col] == 0) || (board[row-1, col+1] == 0)|| (board[row, col+1] == 0)|| (board[row+1, col+1] == 0)|| (board[row+1, col] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if ((row == 1 && col ==5)||(row == 2 && col ==5)||(row == 3 && col ==5)||(row == 4 && col ==5)||(row == 5 && col ==5)||(row == 6 && col ==5))
			{
				if ((board[row-1, col] == 0) ||(board[row+1, col] == 0)||(board[row+1, col-1] == 0)|| (board[row, col-1] == 0)|| (board[row-1, col-1] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if (row == 7 && col ==0)
			{
				if ((board[row-1, col] == 0)|| (board[row-1, col+1] == 0)|| (board[row, col+1] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if ((row == 7 && col ==1)||(row == 7 && col ==2)||(row == 7 && col ==3)||(row == 7 && col ==4))
			{
				if ((board[row-1, col] == 0)|| (board[row-1, col+1] == 0)|| (board[row, col+1] == 0)|| (board[row, col-1] == 0)|| (board[row-1, col-1] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if (row == 7 && col ==5)
			{
				if ((board[row-1, col] == 0)||(board[row, col-1] == 0)|| (board[row-1, col-1] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else
			{
				if ((board[row-1, col] == 0) || (board[row-1, col+1] == 0)|| (board[row, col+1] == 0)|| (board[row+1, col+1] == 0)|| (board[row+1, col] == 0)||
					(board[row+1, col-1] == 0)|| (board[row, col-1] == 0)|| (board[row-1, col-1] == 0))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			
		}
		
		// The following two methods check if the user has requested to move to the tile one space in any direction from their current position
		//(diagonally, sideways, forward and backward) is free
		public static bool Check_if_move_is_viable(int row, int col, int userrow, int usercol)
		{
			if (row == 0 && col == 0)
			{
				if ((userrow == row && usercol ==col+1)|| (userrow == row+1 && usercol ==col+1)||(userrow == row+1 && usercol ==col))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if ((row == 0 && col == 1)||(row == 0 && col == 2)||(row == 0 && col == 3)||(row == 0 && col == 4))
			{
				if ((userrow == row && usercol ==col+1)|| (userrow == row+1 && usercol ==col+1)||(userrow == row+1 && usercol ==col)|| 
					(userrow == row+1 && usercol ==col-1)|| (userrow == row && usercol ==col-1))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if (row == 0 && col == 5)
			{
				if ((userrow == row+1 && usercol ==col)|| (userrow == row+1 && usercol ==col-1)|| (userrow == row && usercol ==col-1))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if ((row == 1 && col ==0)||(row == 2 && col ==0)||(row == 3 && col ==0)||(row == 4 && col ==0)||(row == 5 && col ==0)||(row == 6 && col ==0))
			{
				if ((userrow == row-1 && usercol ==col) || (userrow == row-1 && usercol ==col+1)||(userrow == row && usercol ==col+1)|| 
					(userrow == row+1 && usercol ==col+1)||(userrow == row+1 && usercol ==col))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if ((row == 1 && col ==5)||(row == 2 && col ==5)||(row == 3 && col ==5)||(row == 4 && col ==5)||(row == 5 && col ==5)||(row == 6 && col ==5))
			{
				if ((userrow == row-1 && usercol ==col) || (userrow == row+1 && usercol ==col)|| (userrow == row+1 && usercol ==col-1)|| 
					(userrow == row && usercol ==col-1)|| (userrow == row-1 && usercol ==col-1))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if (row == 7 && col ==0)
			{
				if ((userrow == row-1 && usercol ==col) || (userrow == row-1 && usercol ==col+1)||(userrow == row && usercol ==col+1))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if ((row == 7 && col ==1)||(row == 7 && col ==2)||(row == 7 && col ==3)||(row == 7 && col ==4))
			{
				if ((userrow == row-1 && usercol ==col) || (userrow == row-1 && usercol ==col+1)||(userrow == row && usercol ==col+1)|| 
					(userrow == row && usercol ==col-1)|| (userrow == row-1 && usercol ==col-1))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else if (row == 7 && col ==5)
			{
				if ((userrow == row-1 && usercol ==col)||(userrow == row && usercol ==col-1)|| (userrow == row-1 && usercol ==col-1))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			else
			{
				if ((userrow == row-1 && usercol ==col) || (userrow == row-1 && usercol ==col+1)||(userrow == row && usercol ==col+1)|| 
					(userrow == row+1 && usercol ==col+1)||(userrow == row+1 && usercol ==col)|| (userrow == row+1 && usercol ==col-1)|| 
					(userrow == row && usercol ==col-1)|| (userrow == row-1 && usercol ==col-1))
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
			
		}
		
		
		// Method for displaying the board
		public static void PrintBoard( )
		{
			Console.Clear();
			WriteLine( "    0   1   2   3   4   5" );
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "0 |{0}|{1}|{2}|{3}|{4}|{5}|", Mark( board[ 0, 0 ]), Mark( board[ 0, 1 ]), Mark( board[ 0, 2 ]),Mark( board[ 0, 3 ]), Mark( board[ 0, 4 ]), Mark( board[ 0, 5 ]));
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "1 |{0}|{1}|{2}|{3}|{4}|{5}|", Mark( board[ 1, 0 ]), Mark( board[ 1, 1 ]), Mark( board[ 1, 2 ]),Mark( board[ 1, 3 ]), Mark( board[ 1, 4 ]), Mark( board[ 1, 5 ]));
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "2 |{0}|{1}|{2}|{3}|{4}|{5}|", Mark( board[ 2, 0 ]), Mark( board[ 2, 1 ]), Mark( board[ 2, 2 ]),Mark( board[ 2, 3 ]), Mark( board[ 2, 4 ]), Mark( board[ 2, 5 ]));
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "3 |{0}|{1}|{2}|{3}|{4}|{5}|", Mark( board[ 3, 0 ]), Mark( board[ 3, 1 ]), Mark( board[ 3, 2 ]),Mark( board[ 3, 3 ]), Mark( board[ 3, 4 ]), Mark( board[ 3, 5 ]));
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "4 |{0}|{1}|{2}|{3}|{4}|{5}|", Mark( board[ 4, 0 ]), Mark( board[ 4, 1 ]), Mark( board[ 4, 2 ]),Mark( board[ 4, 3 ]), Mark( board[ 4, 4 ]), Mark( board[ 4, 5 ]));
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "5 |{0}|{1}|{2}|{3}|{4}|{5}|", Mark( board[ 5, 0 ]), Mark( board[ 5, 1 ]), Mark( board[ 5, 2 ]),Mark( board[ 5, 3 ]), Mark( board[ 5, 4 ]), Mark( board[ 5, 5 ]));
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "6 |{0}|{1}|{2}|{3}|{4}|{5}|", Mark( board[ 6, 0 ]), Mark( board[ 6, 1 ]), Mark( board[ 6, 2 ]),Mark( board[ 6, 3 ]), Mark( board[ 6, 4 ]), Mark( board[ 6, 5 ]));
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "7 |{0}|{1}|{2}|{3}|{4}|{5}|", Mark( board[ 7, 0 ]), Mark( board[ 7, 1 ]), Mark( board[ 7, 2 ]),Mark( board[ 7, 3 ]), Mark( board[ 7, 4 ]), Mark( board[ 7, 5 ]));
			WriteLine( "  +---+---+---+---+---+---+" );
			WriteLine( "    0   1   2   3   4   5" );
		}
		static string Mark( int boardValue )
		{
			if( boardValue == 1 ) return " A ";
			if( boardValue == 2 ) return " B ";
			if( boardValue == 3 ) return " \u25a0 ";
			return "   ";
		}
		
	}
	
	
    class Program
    {
        static void Main(string[] args)
        {
			// Variables for the starting platform, tracking turn number, tracking the tiles available for moves
            int turn = 0;
			int round = 1;
            bool gameRunning = true;
			int temprowA = 0;
			int tempcolA = 3;
			int temprowB = 7;
			int tempcolB = 2;
            
			DisplayInstructions();
			
			WriteLine("Enter 1 for when you are ready to proceed with the game "); //Ensures user chooses when to start the game. 
			int ready = int.Parse(ReadLine());										//Need them to be familiar with the instructions
			
			if (ready == 1)
			{
				Console.Clear();
				// Get the name of each player 				
				WriteLine("Enter the first name of player A");
				string nameofplayerA = ReadLine();
				WriteLine("\n\n");
				
				WriteLine("Enter the first name of player B");
				string nameofplayerB = ReadLine();
				WriteLine("\n\n");

				// Show the board at start of the game with players situated at their starting platforms
				Isolation.AddSymbol(0,3,1);
				Isolation.AddSymbol(7,2,2);
				Isolation.PrintBoard();
				
				// Loop that repeats for game
				while(gameRunning)
				{
					// Tell both users which round of the game they are at
					WriteLine("\n");
					WriteLine("Round {0}",round);
					WriteLine("\n");
					
					if(turn % 2 == 0) //Player A turn
					{
						bool availablespaces = Isolation.CheckAvailableSpaces(temprowA,tempcolA);
						
						if (availablespaces)
						{
							// Tell the user whose turn it is
							WriteLine("It is A-Player's turn");
							WriteLine("\n");
							
							// Player A moves
							
							Write("Player A, enter the tile you want to move to: "); // Get coordinates from user for the tile player A wants to move to
							string codeFromPlayer = ReadLine();
							
							int rowFromCode = int.Parse(codeFromPlayer[0].ToString());
							int colFromCode = int.Parse(codeFromPlayer[1].ToString());
							
							bool viablemove = Isolation.Check_if_move_is_viable(temprowA,tempcolA, rowFromCode, colFromCode);
							bool validMove = Isolation.Is_space_free(rowFromCode, colFromCode);
								
							while (!viablemove || !validMove)
							{
								if (!viablemove)
								{
									WriteLine("\n\n");
									WriteLine("Invalid move! You can only move your pawn ONE SPACE in any direction (diagonally, sideways, forward and backward.");
								}
								else if (!validMove)
								{
									WriteLine("\n\n");
									WriteLine("Invalid move! You can only move to an unoccupied tile");
								}
								
								WriteLine("\n\n");
								Write("Player A, enter the tile you want to move to: ");
								codeFromPlayer = ReadLine();
								
								rowFromCode = int.Parse(codeFromPlayer[0].ToString());
								colFromCode = int.Parse(codeFromPlayer[1].ToString());
									
								viablemove = Isolation.Check_if_move_is_viable(temprowA,tempcolA, rowFromCode, colFromCode);
								validMove = Isolation.Is_space_free(rowFromCode, colFromCode);
							}
							
							Isolation.AddSymbol(rowFromCode, colFromCode, 1);
								
							Isolation.RemoveSymbol(temprowA, tempcolA);
							
							temprowA = rowFromCode;
							tempcolA = colFromCode; 
							
							WriteLine("\n");
						
							Write("Enter the tile that you want removed: "); // Get coordinates from user for the tile player A wants to remove
							string tileFromPlayer = ReadLine();
						
							int rowtile = int.Parse(tileFromPlayer[0].ToString());
							int coltile= int.Parse(tileFromPlayer[1].ToString());
							
							bool validsquare = Isolation.Check_if_user_is_removing_starting_platform(rowtile, coltile);
							bool validblock = Isolation.Is_space_free(rowtile, coltile);
							
							while (!validsquare || !validblock)
							{
								if (!validsquare)
								{
									WriteLine("\n\n");
									WriteLine("Invalid move! Cannot remove the starting platform");
								}
								else if (!validblock)
								{
									WriteLine("\n\n");
									WriteLine("Invalid move! You can only remove an unoccupied tile");
								}
								WriteLine("\n\n");
								Write("Enter the tile that you want removed: ");
								tileFromPlayer = ReadLine();
							
								rowtile = int.Parse(tileFromPlayer[0].ToString());
								coltile= int.Parse(tileFromPlayer[1].ToString());
								
								validsquare = Isolation.Check_if_user_is_removing_starting_platform(rowtile, coltile);
								validblock = Isolation.Is_space_free(rowtile, coltile);
							}
							
							Isolation.AddBlock(rowtile, coltile, 3);
								
							round -= 1;
						}
						else 
						{
							
							WriteLine(":-( {0} you have no available moves left :-(  !!!!You have been ISOLATED....................Loser!!!!!! Y_Y  ", nameofplayerA );
							WriteLine("\n\n");
							WriteLine("!!!!!!!!!!!! CONGRATULATIONS {0} !!!!!!!!!!!! You Won! ^_^ ^_^\n\n", nameofplayerB);
							break; 
						}
						
					}
					else
					{
						bool availablespaces = Isolation.CheckAvailableSpaces(temprowB,tempcolB);
						
						if (availablespaces)
						{
							WriteLine("It is B-Player's turn");
							WriteLine("\n");
							
							//player B moves
							
							Write("Player B enter the tile you want to move to: "); // Get coordinates from user for the tile player B wants to move to
							string codeFromPlayer = ReadLine();
							
							int rowFromCode = int.Parse(codeFromPlayer[0].ToString());
							int colFromCode = int.Parse(codeFromPlayer[1].ToString());
							
							bool viablemove = Isolation.Check_if_move_is_viable(temprowB,tempcolB, rowFromCode, colFromCode);
							bool validMove = Isolation.Is_space_free(rowFromCode, colFromCode);
								
							while (!viablemove || !validMove)
							{
								if (!viablemove)
								{
									WriteLine("\n\n");
									WriteLine("Invalid move! You can only move your pawn ONE SPACE in any direction (diagonally, sideways, forward and backward.");
								}
								else if (!validMove)
								{
									WriteLine("\n\n");
									WriteLine("Invalid move! You can only move to an unoccupied tile");
								}
								WriteLine("\n\n");
								Write("Player B enter the tile you want to move to: ");
								codeFromPlayer = ReadLine();
							
								rowFromCode = int.Parse(codeFromPlayer[0].ToString());
								colFromCode = int.Parse(codeFromPlayer[1].ToString());
								
								viablemove = Isolation.Check_if_move_is_viable(temprowB,tempcolB, rowFromCode, colFromCode);
								validMove = Isolation.Is_space_free(rowFromCode, colFromCode);
							}
							
							Isolation.AddSymbol(rowFromCode, colFromCode, 2);
							
							Isolation.RemoveSymbol(temprowB, tempcolB);
							
							temprowB = rowFromCode;
							tempcolB = colFromCode; 
							
							
							WriteLine("\n");
							
							Write("Enter the tile that you want removed: "); // Get coordinates from user for the tile player B wants to remove
							string tileFromPlayer = ReadLine();
							
							int rowtile = int.Parse(tileFromPlayer[0].ToString());
							int coltile= int.Parse(tileFromPlayer[1].ToString());
							
							bool validsquare = Isolation.Check_if_user_is_removing_starting_platform(rowtile, coltile);
							bool validblock = Isolation.Is_space_free(rowtile, coltile);
							
							while (!validsquare || !validblock)
							{
								if (!validsquare)
								{
									WriteLine("\n\n");
									WriteLine("Invalid move! Cannot remove the starting platform");
								}
								else if (!validblock)
								{
									WriteLine("\n\n");
									WriteLine("Invalid move! You can only remove an unoccupied tile");
								}
								WriteLine("\n\n");
								Write("Enter the tile that you want removed: ");
								tileFromPlayer = ReadLine();
							
								rowtile = int.Parse(tileFromPlayer[0].ToString());
								coltile= int.Parse(tileFromPlayer[1].ToString());
								
								validsquare = Isolation.Check_if_user_is_removing_starting_platform(rowtile, coltile);
								validblock = Isolation.Is_space_free(rowtile, coltile);
							}
							
							Isolation.AddBlock(rowtile, coltile, 3);
						}
						else 
						{
							
							WriteLine(":-( {0} you have no available moves left :-(  !!!!You have been ISOLATED....................Loser!!!!!!Y_Y", nameofplayerB);
							WriteLine("\n\n");
							WriteLine("!!!!!!!!!!!! CONGRATULATIONS {0} !!!!!!!!!!!!  You Won! ^_^ ^_^ \n\n", nameofplayerA);
							break;
						}
					}

							
					
					// Print the current state of the board
					Isolation.PrintBoard();
					
					gameRunning = true;
					
					
					
					// Increment turn counter
					turn += 1;
					round += 1;


				}
			}
        }
		
		//Method welcomes user to game and displays game instructions
		static void DisplayInstructions() 
        {
			WriteLine("\n");
			
			WriteLine("**********************************WELCOME TO ISOLATION ---- THE 'DON'T GET STRANDED' STRATEGY GAME************************************");
			WriteLine("\n\n");
			
			WriteLine("In this game each player has a pawn. Pawns are represented by the letters A and B. ");
			WriteLine("You will be asked to state who is Player A and who is Player B later, so take some time to think about it");
			WriteLine("The board has 46 tiles (6 columns and 8 rows)");
			WriteLine("\n\n");
			
			WriteLine("OBJECTIVE OF THE GAME");
			WriteLine("Isolate your opponent's piece so it is impossible for them to move");
			WriteLine("\n\n");
			
			WriteLine("TO START");
			WriteLine("all tiles will be shown as blank space, this indicates that the tile is free");
			WriteLine("Your pawns will be automatically placed on the back or starting platforms for you");
			WriteLine("Player A will be starting the game, so again decide who is going to be which player");
			WriteLine("\n");
			
			WriteLine("THE PLAY");
			WriteLine("On your turn");
			WriteLine("1) Move your pawn one space in any direction (diagonally,sideways, forward, or backward) to an adjacent tile.");
			WriteLine("2) After you move your pawn, remove one tile from any-where on the grid.");
			WriteLine("When you have remove a tile, a white block or square will appear in the position. Neither players can move to that tile");
			WriteLine("How do you do this?");
			WriteLine("You enter the coordinates of the tile for where you would like to place your pawn and for the tile you would like to remove from the board");
			WriteLine("Don't worry you will receive prompts for when you should do so, just follow the instructions clearly.");
			WriteLine("Coordinates are to be input as a code 'ab', where 'a' denotes the row and 'b' denotes the column.");
			WriteLine("Example: 12");
			WriteLine("\n");
			
			WriteLine("Only one pawn may occupy a tile.");
			WriteLine("The starting platforms CANNOT be removed but may be used as tiled spaces throughout the game by either player.");
			WriteLine("\n");
			
			WriteLine("TO WIN");
			WriteLine("Attempt to remove the tiles so as to isolate your opponent's pawn. If your opponent cannot move, YOU WIN.");
			WriteLine("\n");
			
			WriteLine("STRATEGY");
			WriteLine("Attempt to keep your opponent in areas where there are fewer tiles.");
			WriteLine("In the beginning of the game, it may be useful to remove the tiles which are a few grid spaces away from your opponent's pawn"); 
			WriteLine("rather than adjacent to it. You can use your pawn to limit your opponent's range of moves, but be careful, don’t get trapped yourself.");
			WriteLine("\n");
			
			WriteLine("Once you have read and have familiarized yourself with the instructions");
			WriteLine("\n");
		}
    }
												//test data 
		//Move #					Player A					Player B					Move #
		//				Move to tile	Tile to Remove	Move to tile	Tile to Remove	
		//	1				14				62				63				23				1
		//	2				24				53				54				34				2
		//	3				33				44				55				42				3
		//	4				32				45				65				31				4
		//	5				22				64				74				21				5
		//	6				11				73				75				01				6
		//	7				10				65				74				11				7
		//	8				20				75				63				30				8
		//	9				10				74				52				00				9
		//	10				20				51				41				10				10
		
		//PLAYER B WILL WIN AND PLAYER A WILL LOSE IF THIS DATA IS USED

}