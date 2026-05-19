import readline from "readline";

// Number Guessing Game — Node.js Console Version
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

const secret = Math.floor(Math.random() * 100) + 1;
let attempts = 0;

console.log("🎯 Guess The Number (1 - 100)");
console.log("------------------------------");

function askGuess() {
  rl.question("Your guess: ", (input) => {
    const guess = parseInt(input);

    // validate
    if (!guess || guess < 1 || guess > 100) {
      console.log("⚠️  Enter a valid number between 1 and 100!\n");
      return askGuess();
    }

    attempts++;

    if (guess < secret) {
      console.log("📉 Too low!\n");
      askGuess();
    }

    else if (guess > secret) {
      console.log("📈 Too high!\n");
      askGuess();
    }

    else {
      console.log(
        `🎉 Correct! It was ${secret}! You got it in ${attempts} attempt${attempts > 1 ? "s" : ""}!`,
      );
      rl.close();
    }
  });
}

askGuess();
