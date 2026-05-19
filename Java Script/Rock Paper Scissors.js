import readline from "readline";

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

const options = ["rock", "paper", "scissors"];

function getComputerchoice() {
  const rno = Math.ceil(Math.random() * 3) - 1;

  if (rno === 0) {
    console.log();
  }
  //  console.log(rno);
  rl.close();
}

getComputerchoice();
