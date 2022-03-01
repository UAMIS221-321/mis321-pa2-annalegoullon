using System;

namespace mis321_pa2_annalegoullon{
    class Program{
        static void Main(string[] args){
            //start with two empty player objects
            Player player1 = new Player();
            Player player2 = new Player();
            StartMenu(ref player1,ref player2);

            if(player1.firstTurn){
                RunBattle(player1,player2);
            }else{
                RunBattle(player2, player1);
            }   

        }
        static void StartMenu(ref Player p1, ref Player p2){
            Character c1;
            Character c2;

            Console.WriteLine("Welcome to the Battle of Calypso!\nPlayer 1, please enter your name:");
            string name1 = Console.ReadLine();
            Console.WriteLine(name1 + ", please choose your character\n1.Jack Sparrow\n2.Davy Jones\n3.Will Turner");
            int input1 = int.Parse(Console.ReadLine());

            //check for valid input
            while(input1>3 || input1<1){
                Console.WriteLine("Invalid Input! Please try again");
                Console.WriteLine(name1 + ", please choose your character\n1.Jack Sparrow\n2.Davy Jones\n3.Will Turner");
                input1 = int.Parse(Console.ReadLine());
            }
            if(input1 == 1){
                c1 = new JackSparrow();
                p1 = new Player(){c = c1, playerName = name1, firstTurn = false};
            }else if(input1 == 2){
                c1 = new DavyJones();
                p1 = new Player(){c = c1, playerName = name1, firstTurn = false};
            }else{
                c1 = new WillTurner();
                p1 = new Player(){c = c1, playerName = name1, firstTurn = false};
            }
            Console.Clear();
            Console.WriteLine("Player 2, please enter your name:");
            string name2 = Console.ReadLine();
            Console.WriteLine(name2 + ", please choose your character\n1.Jack Sparrow\n2.Davy Jones\n3.Will Turner");
            int input2 = int.Parse(Console.ReadLine());

            //check for valid input
            while(input2>3 || input2<1){
                Console.WriteLine("Invalid Input! Please try again");
                Console.WriteLine(name2 + ", please choose your character\n1.Jack Sparrow\n2.Davy Jones\n3.Will Turner");
                input2 = int.Parse(Console.ReadLine());
            }
            if(input2 == 1){
                c2 = new JackSparrow();
                p2 = new Player(){c = c2, playerName = name2, firstTurn = false};
            }else if(input2 == 2){
                c2 = new DavyJones();
                p2 = new Player(){c = c2, playerName = name2, firstTurn = false};
            }else{
                c2 = new WillTurner();
                p2 = new Player(){c = c2, playerName = name2, firstTurn = false};
            }

            Console.Clear();
            Console.WriteLine("Time to decide who gets to go first! Randomly choosing first player...");
            //random generated int to see who goes first
            Random rand = new Random();
            int num = rand.Next(1,3);
            if(num == 1){
                p1.firstTurn = true;
                Console.WriteLine(p1.playerName + " goes first!");
            }else{
                p2.firstTurn = true;
                Console.WriteLine(p2.playerName + " goes first!");
            }
            
        }
        static void RunBattle(Player player1, Player player2){
            bool battleOver = false;
            int roundNum = 1; 

            Character char1 = player1.c;
            Character char2 = player2.c;

            double typeBonus1 = CalcTypeBonus(char1,char2);
            double typeBonus2 = CalcTypeBonus(char2,char1);

            Console.WriteLine("Beginning Player Stats:");
            PrintPlayerStats(player1, char1);
            PrintPlayerStats(player2, char2);

            while(!battleOver){
                Console.WriteLine("Enter 1 to continue the battle, 2 to display player stats, or 3 to exit");
                Console.WriteLine("Round #" + roundNum);
                int input = int.Parse(Console.ReadLine());
                Console.Clear();

                switch(input){
                    case 1:
                    // player 1 attacks player 2 
                    RunAttack(ref char1, ref char2,typeBonus1);
                    Console.WriteLine("Updated current defending player stats: ");
                    PrintPlayerStats(player2,char2);

                    //check if hit from player 1 killed player 2
                    if(char2.health<=0){
                        Console.WriteLine(player2.playerName + " has been defeated. Congrats, " + player1.playerName + " you win!!!");
                        battleOver = true;
                        break;
                    }else{
                        //player 2 attacks player 1
                        RunAttack(ref char2, ref char1,typeBonus2);
                        Console.WriteLine("Updated current defending player stats: ");
                        PrintPlayerStats(player1,char1);
                        roundNum++;
                        break;
                    }
                    case 2: 
                    PrintPlayerStats(player1,char1);
                    PrintPlayerStats(player2,char2);
                    break;

                    case 3:
                    Environment.Exit(0);
                    break;

                    default:
                    Console.WriteLine("Incorrect input please try again!");
                    break;
                }
                //checks for winner
                if(char1.health<=0){
                    Console.WriteLine(player1.playerName + " has been defeated. Congrats, " + player2.playerName + " you win!!!");
                    battleOver = true;
                }

            }
        }

        //calculates the type bonus for a charcter and returns the amount
        static double CalcTypeBonus(Character char1, Character char2){
            if(char1.name == "Jack Sparrow" && char2.name == "Will Turner"){
                return 1.2;
            }else if(char1.name == "Will Turner" && char2.name == "Davy Jones"){
                return 1.2;
            }else if(char1.name == "Davy Jones" && char2.name == "Jack Sparrow"){
                return 1.2;
            }else{
                return 1;
            }
        }

        static void PrintPlayerStats(Player p, Character c){
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Player Name: " + p.playerName + " || " + "Character Name: " + c.name + " || " + "Max Power: " + c.maxPower +" || " + "Health: " + c.health + " || " + "Attack Strength: " + c.attackStrength +" || " +"Defensive Power: " + c.defensivePower);
            Console.WriteLine("-----------------------------------------------------------------------------");
        }
        //runs a single attack and changes hea lth of players accordingly
        static void RunAttack(ref Character attacker, ref Character defender, double bonus){
            attacker.characterAttack.Attack();
            Console.WriteLine("-------------------------------------------");
            double damage = (attacker.attackStrength - defender.defensivePower) * bonus;
            if(bonus == 1.2){
                Console.WriteLine("***************************************************");
                Console.WriteLine("Type bonus!! " + attacker.name + " causes 20% more damage!");
                Console.WriteLine("***************************************************");
            }
            Console.WriteLine(attacker.name + " attacks with " + (attacker.attackStrength * bonus) + " points of power");
            Console.WriteLine("-------------------------------------------");
            //if the defenders defensive power is greater than the attackers attack strength the attack is considered blocked and defenders health is only affected by 1
            if(damage<=0){

                Console.WriteLine(attacker.name + "'s attack was blocked by " + defender.name + "'s defense.\n" + defender.name + "'s health drops by 1");
                defender.health--;
                Console.WriteLine("-------------------------------------------");
            }else{
                defender.health-=damage;
                Console.WriteLine(attacker.name + " caused " + damage + " points of damage to " + defender.name);

            }



        }
    } 
}
