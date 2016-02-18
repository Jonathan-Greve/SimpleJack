# SimpleJack

A simple implementation of Simple Jack in F#. The code was written to simulate
3000 games between 5 AI's. Each AI using a different strategy. 
I made a quick patch to allow Humans players to play. The code needs to be refactored (especially Main.fs which is currently housing dupplicate functions).


Compile in Mono: fsharpc CardDeck.fs Strategy.fs Player.fs Main.fs


UnitTest Compile in Mono: fsharpc CardDeck.fs Strategy.fs Player.fs Main.fs UnitTest.fs


How to run Main.exe: mono Main.exe


