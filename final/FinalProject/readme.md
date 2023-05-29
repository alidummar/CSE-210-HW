Hangman Game
This is a console-based Hangman game developed as a fun and interactive word-guessing game. In this game, the player will be challenged to guess a word within a certain number of attempts. The goal is to correctly guess all the letters in the word before the hangman figure is completely drawn.

How to Play
The computer will randomly select a word from a provided list.
The word will be displayed as a series of dashes, representing each letter in the word.
The player has six guesses to correctly guess the word by suggesting letters one at a time.
Each incorrect guess will result in a part of the hangman figure being drawn.
The game ends when the player either guesses the word correctly or the hangman figure is completely drawn.
To win, the player must guess all the letters in the word before the hangman figure is completed.
Scoring
A scoring mechanism is implemented to provide a measure of the player's performance. The game offers two scoring options:

Simple Scoring: This scoring system assigns scores based on the number of guesses made. The fewer guesses required, the higher the score.
Complex Scoring: This scoring system takes into account both the number of guesses made and the length of the word. Longer words require more effort to guess correctly, resulting in higher scores for successfully guessing longer words with fewer attempts.
Project Structure
The project is structured around the following classes:

Game: Responsible for managing the game flow and interactions between other classes.
Word: Represents a word to be guessed by the player.
Dictionary: Provides a collection of words to be used in the game.
Player: Handles the state of the current player's attempt, including guessed letters and wrong guesses count.
Renderer: Renders the game interface and displays information to the console/screen.
Scoreboard: Keeps track of the player's score and displays it.
ScoringRules (abstract class): Defines the scoring rules for the game.
SimpleScoring (implementation of ScoringRules): Assigns scores based on the number of guesses made.
ComplexScoring (implementation of ScoringRules): Assigns scores based on the number of guesses made and word length.