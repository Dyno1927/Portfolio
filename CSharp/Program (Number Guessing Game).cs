//Greeating the user and explaining the game.
Console.WriteLine("Welcome to the Number Guessing Game!");
Console.WriteLine("I have selected a random number between 1 and 100. Can you guess it?");

//Generating a random number between 1 and 100.
Random r_no = new Random();
int number_to_guess = r_no.Next(1, 101);

//Asking the user for their guess.
Console.WriteLine("Enter your guess: ");
int guess = int.Parse(Console.ReadLine() ?? "0");

//Attempts
int attempts = 0;

//Checking if the user's guess is correct.
while (guess != number_to_guess)
{
    attempts++;
    if (guess < number_to_guess)
    {
        Console.WriteLine("Too Low, Try again:");
        guess = int.Parse(Console.ReadLine() ?? "0");
    }

    else if (guess > number_to_guess)
    {
        Console.WriteLine("Too High, Try again:");
        guess = int.Parse(Console.ReadLine() ?? "0");
    }
}

//Congratulating the user for guessing the correct number.
if (guess == number_to_guess)
{
    Console.WriteLine("Congratulations! You guessed the correct number "
    + number_to_guess + " in " + (attempts + 1) + " attempts!");
}
