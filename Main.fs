//Main.fs

namespace SimpleJack
open SimpleJack

module Main =

  type Main () =

//Counts how many rounds have been played
    let mutable roundNumber = 0
//Counts how many times each player has won    
    let player1Wins : int ref = ref 0
    let player2Wins : int ref = ref 0
    let player3Wins : int ref = ref 0    
    let player4Wins : int ref = ref 0
    let player5Wins : int ref = ref 0        
    let dealer1Wins : int ref = ref 0
    
    member this.Game x =
        let humanNum =
            System.Console.WriteLine ("How many Humans?")
            int(System.Console.ReadLine ())
        humanNum

        while roundNumber < x do

//Create a new player every round (otherwise they would keep their old hand). 
            let ai1 = new Player.Ai (4)
            let ai2 = new Player.Ai (2)
            let ai3 = new Player.Ai (4)
            let ai4 = new Player.Ai (2)
            let ai5 = new Player.Ai (4)
            let hum1 = new Player.Human()
            let hum2 = new Player.Human()
            let hum3 = new Player.Human()
            let hum4 = new Player.Human()
            let hum5 = new Player.Human()
            let dealer = new Player.Ai (2)
        
            let mutable deckList = CardDeck.Deck.DeckCreator //Create a new deck every round.
            CardDeck.deckList <- deckList

            this.PlayerAction dealer

            let player1 =
                if humanNum > 0 then
                    this.PlayerAction1 hum1
                    this.Check1 dealer hum1 player1Wins
                else
                    this.PlayerAction ai1
                    this.Check dealer ai1 player1Wins

            let player2 =
                if humanNum > 1 then
                    this.PlayerAction1 hum2
                    this.Check1 dealer hum2 player2Wins
                else
                    this.PlayerAction ai2
                    this.Check dealer ai2 player2Wins
        
            let player3 =
                if humanNum > 2 then
                    this.PlayerAction1 hum3
                    this.Check1 dealer hum3 player3Wins
                else
                    this.PlayerAction ai3
                    this.Check dealer ai3 player3Wins
                    
            let player4 =
                if humanNum > 3 then
                    this.PlayerAction1 hum4
                    this.Check1 dealer hum4 player4Wins
                else
                    this.PlayerAction ai4
                    this.Check dealer ai4 player4Wins
                    
            let player5 =
                if humanNum > 4 then
                    this.PlayerAction1 hum5
                    this.Check1 dealer hum5 player5Wins
                else
                    this.PlayerAction ai5
                    this.Check dealer ai5 player5Wins


            printfn "Dealer Value: %d" (dealer.HandValue)
          


            roundNumber <- roundNumber + 1

        printfn "Player1 wins: %d" !player1Wins
        printfn "_________________"
        printfn "Player2 wins: %d" !player2Wins
        printfn "_________________"
        printfn "Player3 wins: %d" !player3Wins
        printfn "_________________"
        printfn "Player4 wins: %d" !player4Wins
        printfn "_________________"
        printfn "Player5 wins: %d" !player5Wins
        printfn "_________________"
        printfn "Dealer wins: %d" !dealer1Wins

//Duplicate functions because Human and Ai players can't use the same method (they arent the same type).
//We tried to upcast, but then Strat became undefined.
    member this.Check deal play (str: int ref) =
        if   deal.HandValue <= 21 && deal.HandValue > play.HandValue then dealer1Wins := !dealer1Wins + 1
        elif play.HandValue <= 21 && play.HandValue > deal.HandValue then str         := !str + 1
        elif deal.HandValue <= 21 && play.HandValue = deal.HandValue then dealer1Wins := !dealer1Wins + 1
        elif deal.HandValue > 21  && play.HandValue <= 21            then str         := !str + 1
        elif play.HandValue > 21  && deal.HandValue <= 21            then dealer1Wins := !dealer1Wins + 1
        elif deal.HandValue > 21  && play.HandValue >  21            then dealer1Wins := !dealer1Wins

    member this.Check1 deal play (str: int ref) =
        if   deal.HandValue <= 21 && deal.HandValue > play.HandValue then dealer1Wins := !dealer1Wins + 1
        elif play.HandValue <= 21 && play.HandValue > deal.HandValue then str         := !str + 1
        elif deal.HandValue <= 21 && play.HandValue = deal.HandValue then dealer1Wins := !dealer1Wins + 1
        elif deal.HandValue > 21  && play.HandValue <= 21            then str         := !str + 1
        elif play.HandValue > 21  && deal.HandValue <= 21            then dealer1Wins := !dealer1Wins + 1
        elif deal.HandValue > 21  && play.HandValue >  21            then dealer1Wins := !dealer1Wins
        else dealer1Wins := !dealer1Wins

    member this.PlayerAction player =
        while player.HandValue <= 21 &&
        not (CardDeck.Card.CardExist (player.HandList) ( (CardDeck.StandSuit), (CardDeck.StandRank) )) do
            (player.Strat)
            if player.HandValue > 21 && CardDeck.Card.Ace11Exists player.HandList then
                player.AceSwitcher player.HandList
                (player.HandList)
                (player.HandValue)
            else (player.HandValue)

    member this.PlayerAction1 (player:Player.Human) =
        while player.HandValue <= 21 &&
        not (CardDeck.Card.CardExist (player.HandList) ( (CardDeck.StandSuit), (CardDeck.StandRank) )) do
            printfn "%A" (player.Strat)
            if player.HandValue > 21 && CardDeck.Card.Ace11Exists player.HandList then
                player.AceSwitcher player.HandList
                printfn "%A" (player.HandList)
                printfn "%A" (player.HandValue)
            else printfn "%A" (player.HandValue)


        
        
  let Main = new Main()

  System.Console.Write ("How many game to play?")
  (Main.Game (int(System.Console.ReadLine())))

