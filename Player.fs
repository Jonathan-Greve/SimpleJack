// Player.fs
namespace SimpleJack

open SimpleJack //This module uses the methods from the CardDeck module to Hit.


module Player =

//This random generator is used when drawing cards, and for Strategy 4.
  type StaticRandomGenerator () =
    static let rand = new System.Random ()
    static do printfn "Static random object has been created"
    member this.GetRand (a,b)= rand.Next (a,b)
  let random = new StaticRandomGenerator ()

//Player Super-Class
  type Player () =

    let mutable currentHand = []

    //Public wrapper for the currentHand identifier.
    member this.HandList =
      currentHand
//Still have to do something about aces being either 1 or 11 (right now ace = 1).
    member this.HandValue =
      let mutable currentValue = List.fold (fun xs x -> CardDeck.Card.CardValue x + xs) 0 currentHand
      currentValue// -v is later used to subtract 10 when you hold an ace and value > 21

    member this.Hit =
      let mutable randNum = random.GetRand(1, (List.length CardDeck.deckList) )
      let mutable cardReturn = CardDeck.Deck.CardReturn randNum CardDeck.deckList
      
      CardDeck.deckList <- CardDeck.Deck.RemoveCard randNum CardDeck.deckList
      currentHand  <- cardReturn::currentHand
      cardReturn

//Returns the card: (StandSuit,StandRank).
    member this.Stand =
      currentHand <- ((CardDeck.StandSuit),(CardDeck.StandRank))::currentHand
      ((CardDeck.StandSuit),(CardDeck.StandRank))

    member this.StrategyChooser strat =
      match strat with
        | 1 -> Strategy.Strategy1().Strat1 (this.HandValue)
        | 2 -> Strategy.Strategy2().Strat2 (this.HandValue)
        | 3 -> Strategy.Strategy3().Strat3 (this.HandValue)
        | 4 -> Strategy.Strategy4().Strat4 (random.GetRand(0,100))
        | 5 ->
            if Strategy.Strategy5().Strat5 (this.HandList) then this.StrategyChooser 2
            else this.StrategyChooser 1

//This function switch Ace11 out with Ace1 when called.
    member this.AceSwitcher lst =
        printfn "Ace Switcher Initiated"
        if CardDeck.Card.CardExist lst (CardDeck.Spades,CardDeck.Ace11) then
            let index = List.findIndex (fun x -> x = (CardDeck.Spades,CardDeck.Ace11)) lst
            currentHand <- (CardDeck.Spades,CardDeck.Ace1)::(CardDeck.Deck.RemoveCard index lst)
        elif CardDeck.Card.CardExist lst (CardDeck.Hearts,CardDeck.Ace11) then
            let index = List.findIndex (fun x -> x = (CardDeck.Hearts,CardDeck.Ace11)) lst
            currentHand <- (CardDeck.Hearts,CardDeck.Ace1)::(CardDeck.Deck.RemoveCard index lst)
        elif CardDeck.Card.CardExist lst (CardDeck.Clubs,CardDeck.Ace11) then
            let index = List.findIndex (fun x -> x = (CardDeck.Clubs,CardDeck.Ace11)) lst
            currentHand <- (CardDeck.Clubs,CardDeck.Ace1)::(CardDeck.Deck.RemoveCard index lst)
        elif CardDeck.Card.CardExist lst (CardDeck.Diamonds,CardDeck.Ace11) then
            let index = List.findIndex (fun x -> x = (CardDeck.Diamonds,CardDeck.Ace11)) lst
            currentHand <- (CardDeck.Diamonds,CardDeck.Ace1)::(CardDeck.Deck.RemoveCard index lst)            

//Dealer class
  type Dealer () =
    inherit Player ()
    
    member this.Strat =
        if this.StrategyChooser 2 then this.Hit
        else this.Stand
      
//Human class
  type Human () =
    inherit Player ()

    member this.Strat =
      let mutable input =
        System.Console.Write ("Write 'Yes' to Hit and 'No' to Stand, then press <Return>")
        System.Console.ReadLine ()
      if input = "Yes" then this.Hit
      elif input = "No" then this.Stand
      else this.Strat

//AI class
  type Ai (strategy) =
    inherit Player ()
       
    member this.Strat =
      if (this.StrategyChooser strategy) then (this.Hit)
      else (this.Stand)




// //Some Unit Tests. All the tested functions work!      
   let Player = new Player ()
//   printfn "%i" (List.length CardDeck.deckList)
//   printfn "%A" (Player.Hit)
//   printfn "%A\n" (Player.HandList )  
//   printfn "%i" (List.length CardDeck.deckList)  
//   printfn "%A" (Player.Hit)
//   printfn "%i\n" (List.length CardDeck.deckList)
//   printfn "%A" (Player.HandList )
//   printfn "%A\n" (Player.HandValue)
//   printfn "%A" CardDeck.deckList

//   printfn "___________________________________________________________________________"
// //Still works for two players (Both Players share the same card deck, yes!)
//   let Dealer = new Dealer ()
//   printfn "%i" (List.length CardDeck.deckList)
//   printfn "%A" (Dealer.Hit)
//   printfn "%A\n" (Dealer.HandList )  
//   printfn "%i" (List.length CardDeck.deckList)  
//   printfn "%A" (Dealer.Hit)
//   printfn "%i\n" (List.length CardDeck.deckList)
//   printfn "%A" (Dealer.HandList )
//   printfn "%A\n" (Dealer.HandValue)
//   printfn "%A" CardDeck.deckList
//   printfn "%A" (Dealer.DealerStrat)

//   printfn "___________________________________________________________________________"
// //Still works for two players (Both Players share the same card deck, yes!)
//   let Human = new Human ()
//   printfn "%i" (List.length CardDeck.deckList)
//   printfn "%A" (Human.Hit)
//   printfn "%A\n" (Human.HandList )  
//   printfn "%i" (List.length CardDeck.deckList)  
//   printfn "%A" (Human.Hit)
//   printfn "%i\n" (List.length CardDeck.deckList)
//   printfn "%A" (Human.HandList )
//   printfn "%A\n" (Human.HandValue)
//   printfn "%A" CardDeck.deckList
//   printfn "%A" (Human.HumanStrat) 
        



