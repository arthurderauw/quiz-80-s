using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;


namespace quizEngine
{
    class Program
    {
        private static int score = 0;
        static void Main(string[] args)
        {    
            //create questions and answers            
            List<Question> questions = CreateQuestions();
                       
            Console.ForegroundColor = ConsoleColor.White;
            
            //loop through questions
            int i = 0;
            foreach(Question q in questions){
                Console.Clear();
                Console.WriteLine("Score : "+score);
                i++;
                Console.WriteLine("question "+i+": "+ q.GetString());
                int j = 0;
                foreach(Answer a in q.GetOptions()){
                    j++;
                    Console.WriteLine("Type  "+ j + " for : "+a.GetString());   
                }
                
                //Await player input and validate if it's an int
                int input;
                bool parsed = false;
                do{
                    Console.WriteLine("Please answer with a number");
                    parsed = int.TryParse(Console.ReadLine(), out input);
                }
                while(!parsed);
                 
                int result = q.AnswerIt(input-1);//returns -1 if wrong

                if(result > -1){//RIGHT
                    score += result;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkCyan;                    
                    Console.WriteLine("Correct!");
                    Console.WriteLine("+" +result);
                    Console.Beep();
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;    
                }else{//WRONG
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;                    
                    Console.WriteLine("WRONG!");
                    Console.Beep();
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;                       
                }                
            }
            //After questions are answered player enters name for highscore
            Console.Clear();
            Console.WriteLine("Game Over your score is : "+ score + " points");       
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();
            HighScore.WriteHighScore(playerName,score,"highScore.txt");        


            //print highscore after highscore is saved
            string[] highScore = ListSorter.GetSortedHighScore("highScore.txt");
            
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("+++++++++++++ Highscore +++++++++++++");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            int count = highScore.Length;
            if(count>10)count =10;
            for(int k=0;k<count;k++){
                Console.WriteLine(highScore[k]);
            }   
        }
       
        static List<Question> CreateQuestions(){
             return new List<Question>{
            
                new Question("Wat was het populairste liedje uit de 80's?",
                50,
                new List<Answer>{
                    new Answer("Billie Jean — Michael Jackson"),
                    new Answer("Eye Of The Tiger — Survivor"), 
                    new Answer("The Time Of My Life-Bill Medley & Jennifer Warnes"),
                    new Answer("Don’t Stop Believin’ — Journey")
                    },
                3),
                new Question("Wie schreef HOW ‘BOUT US?",
                50,
                new List<Answer>{
                    new Answer("CHAMPAIGN"),
                    new Answer("PETER SCHILLING"), 
                    new Answer("FLOCK OF SEAGULLS")
                    },
                0),
                new Question("Welke groep scoorde met “IT’S RAINING MEN” een hit?",
                50,
                new List<Answer>{
                    new Answer("WEATHER GIRLS"),
                    new Answer("KING"), 
                    new Answer("RAY PARKER JR.")
                    },
                0),
                new Question("Welke hit was niet van Whitney Houston?",
                50,
                new List<Answer>{
                    new Answer("I will always love you"),
                    new Answer("One moment in time"), 
                    new Answer("My heart will go on"), 
                    new Answer("So emotional")
                    },
                1),
                new Question("Bij welke band hoort Benny Andersson? ",
                50,
                new List<Answer>{
                    new Answer("ABBA"),
                    new Answer("QUEEN"),
                    new Answer("The Cure")
                    },
                0),
                new Question("Wie maakte 'Crazy Little Thing Called Love'?",
                50,
                new List<Answer>{
                    new Answer("ABBA"),
                    new Answer("Diana Ross"),
                    new Answer("QUEEN"),
                    },
                2),
                new Question("Welke nummer 1 hit heeft Olivia Newton-John gereleased in 1981?",
                50,
                new List<Answer>{
                    new Answer("Twist of Fate"),
                    new Answer("Physical"),
                    new Answer("Magic"),
                    },
                1),
                new Question("hoeveel songs heeft Michael Jackson uitgebracht in de 80's",
                50,
                new List<Answer>{
                    new Answer("20"),
                    new Answer("10"),
                    new Answer("15"),
                    },
                2),
                new Question("Wie maakte Rosanna?",
                50,
                new List<Answer>{
                    new Answer("Boz Scaggz"),
                    new Answer("Johnny Kemp"),
                    new Answer("Toto"),
                    },
                2),
                new Question("Hoe stierf Bob Marley?",
                50,
                new List<Answer>{
                    new Answer("Overdosis drugs"),
                    new Answer("Kanker"),
                    new Answer("Vermoord"),
                    },
                1),

            };

        }
        
    }
}
