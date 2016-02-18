//UnitTest.fs

namespace SimpleJack
open SimpleJack
module Unittest =
    let Card = new CardDeck.Card ()
    let Deck = new CardDeck.Deck ()

//Test af RankMatch funktionen. "member RankMatch : rank:Rank -> int"
    printfn "Card.RankMatch Unittest"
    printfn "Should return 1: %A" (Card.RankMatch (CardDeck.Ace1))   //Returns the integer 1
    printfn "Should return 11: %A" (Card.RankMatch (CardDeck.Ace11))  //Returns the integer 11
    printfn "Should return 0: %A" (Card.RankMatch (CardDeck.StandRank)) // Returns the integer 0
    printfn "\n"    


//Test af CardValue funktionen. "member RankMatch : rank:Rank -> int"
    printfn "Card.CardValue Unittest"
    printfn "Should return 1: %A" (Card.CardValue (CardDeck.Spades,CardDeck.Ace1))
    printfn "Should return 11: %A" (Card.CardValue (CardDeck.Spades,CardDeck.Ace11))
    printfn "Should return 10: %A" (Card.CardValue (CardDeck.Diamonds,CardDeck.Queen))
    printfn "\n"
    
//Test af CardExist funktionen. "CardExist : lst:('a * 'b) list -> a:'a * b:'b -> bool when 'a : equality and 'b : equality"
    printfn "Card.CardExist Unittest"
    let list1 = [(CardDeck.Hearts,CardDeck.King);(CardDeck.Spades,CardDeck.Ace11)]
    printfn "Should return True: %A" (Card.CardExist list1 (CardDeck.Spades,CardDeck.Ace11))
    printfn "Should return False: %A" (Card.CardExist list1 (CardDeck.Spades,CardDeck.Ace1))    
    printfn "\n"
    
//Test af Ace11Exists funktionen. "member Ace11Exists : lst:(Suit * Rank) list -> bool"
    printfn "Card.Ace11Exists Unittest"
    let list2 = [(CardDeck.Diamonds,CardDeck.Two);(CardDeck.Spades,CardDeck.Five)]
    printfn "Should return True: %A" (Card.Ace11Exists list1)
    printfn "Should return False: %A" (Card.Ace11Exists list2)
    printfn "\n"
    
//Test af DeakCreator funktionen. "member CardNumber : input:int -> Suit * Rank"
    printfn "Deck.DeckCreator Unittest"
    printfn "Should return a deck containing 52 distinct cards: %A" (Deck.DeckCreator)
    printfn "\n"        

//Test af CardReturn funktionen. "member CardReturn : index:int -> lst:'a list -> 'a"
    printfn "Deck.CardReturn Unittest"
    let deck1 = Deck.DeckCreator
    printfn "Should return the 1st card in the deck (index 0): %A" (Deck.CardReturn 0 deck1)
    printfn "\n"        

//Test af RemoveCard funktionen. "member RemoveCard : index:int -> lst:'a list -> 'a list"
    printfn "Deck.RemoveCard Unittest"
    printfn "Should remove the 1st card in the deck (index 0): %A" (Deck.RemoveCard 0 deck1)
    printfn "\n" 

//Test af CardNumber funktionen. "member CardNumber : input:int -> Suit * Rank"
    printfn "Deck.CardNumber Unittest"
    printfn "Should return (Clubs,King): %A" (Deck.CardNumber 39)
    printfn "Should return (Diamonds,King): %A" (Deck.CardNumber 52)    
    printfn "\n"

    let Strategy = new Strategy.Strategy ()
    let Strategy1 = new Strategy.Strategy1 ()
    let Strategy2 = new Strategy.Strategy2 ()
    let Strategy3 = new Strategy.Strategy3 ()
    let Strategy4 = new Strategy.Strategy4 ()
    let Strategy5 = new Strategy.Strategy5 () 
    
//Test af StrategyInit funktionen: "member StrategyInit : p:('a -> 'b) -> x:'a -> 'b"
    printfn "Strategy.StrategInit Unittest"
    printfn "Should return True: %A" (Strategy.StrategyInit (fun x -> x < 15) 14)
    printfn "Should return False: %A" (Strategy.StrategyInit (fun x -> x < 15) 16)    
    printfn "\n"

//Test af Strat1 funktionen: "member Strat1 : x:int -> bool"
    printfn "Strategy1.Strat1 Unittest"
    printfn "Should return True: %A" (Strategy1.Strat1 15)
    printfn "Should return False: %A" (Strategy1.Strat1 16)
    printfn "\n"

//Test af Strat2 funktionen: "member Strat2 : x:int -> bool"
    printfn "Strategy2.Strat2 Unittest"
    printfn "Should return True: %A" (Strategy2.Strat2 15)
    printfn "Should return False: %A" (Strategy2.Strat2 21)
    printfn "\n"

//Test af Strat3 funktionen: "member Strat3 : x:int -> bool"
    printfn "Strategy3.Strat3 Unittest"
    printfn "Should return True: %A" (Strategy3.Strat3 18)
    printfn "Should return False: %A" (Strategy3.Strat3 20)
    printfn "\n"

//Test af Strat4 funktionen: "member Strat4 : x:int -> bool"
    printfn "Strategy4.Strat4 Unittest"
    printfn "Should return True: %A" (Strategy4.Strat4 49)
    printfn "Should return False: %A" (Strategy4.Strat4 50)
    printfn "\n"

//Test ab Strat5 funktionen: "member Strat5 : x:(Suit*Rank) list -> bool"
    printfn "Strategy5.Strat5 Unittest"
    printfn "Should return True: %A" (Strategy5.Strat5 list1)
    printfn "Should return False: %A" (Strategy5.Strat5 list2)
    printfn "\n"

    let Player = new Player.Player ()
    let random = new Player.StaticRandomGenerator ()
    
//Test af GetRand funktionen: "member GetRand : a:int * b:int -> int"
    printfn "Random.GetRand Unittest"
    let mutable x = 0
    while x < 10 do
        printfn "%A" (random.GetRand (0,100))
        x <- x + 1
    printfn "If above numbers seem random, the function works.\n" 

//Test af HandList funktionen: "member HandList : obj list"
    let mutable currentHand = list1
    printfn "Should print '[]': %A\n" (Player.HandList)
    
//Test af Hit funktionen: "member Hit : Suit*Rank"
    printfn "Should return a random card from deckList: %A\n" (Player.Hit)
    printfn "Should return a random card from deckList: %A\n" (Player.Hit)    
    

//Test af Stand funktionen: "member Stand : Suit*Rank"
    printfn "Should print '(StandSuit, StandRank)': %A\n" (Player.Stand)
    
//Test af Stand funktionen: "member StrategyChooser : strat: int -> bool
    printfn "Should print either true or false: %A.\n" (Player.StrategyChooser 1) //Depends on the above unittest hit.

//Test af Stand funktionen: "member AceSwitcher : Suit*Rank"
    let mutable ace11List = [(CardDeck.Diamonds,CardDeck.Ace11);(CardDeck.Spades,CardDeck.Ace11)]
    printfn "%A" ace11List
    Player.AceSwitcher ace11List
    printfn "Should print the above deck but one Ace1 instead of Ace11: %A.\n" (Player.HandList)

//Test af PlayerAction funktionerne
    let main = new Main.Main()
    let player1 = new Player.Ai (1)
    let dealer = new Player.Ai (2)
    main.PlayerAction player1
    main.PlayerAction dealer    
    printfn "Should print non-0 values: Player value: %A. Dealer value: %A" (player1.HandValue) (dealer.HandValue)
    
