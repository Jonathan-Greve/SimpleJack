namespace SimpleJack

//This module creates all the functions neccesarry to Create and Match cards.
module CardDeck =

  type Suit = Spades | Hearts | Clubs | Diamonds | StandSuit
  
  type Rank =
    | Two | Three | Four  | Five 
    | Six | Seven | Eight | Nine
    | Ten | Jack  | Queen | King
    | Ace1| Ace11 | StandRank
             
  type Card () =

    member this.RankMatch (rank:Rank) =
      match rank with
        | Ace1  -> 1
        | Ace11 -> 11
        | Two   -> 2
        | Three -> 3
        | Four  -> 4
        | Five  -> 5
        | Six   -> 6
        | Seven -> 7
        | Eight -> 8
        | Nine  -> 9
        | Ten   -> 10
        | Jack  -> 10
        | Queen -> 10
        | King  -> 10
        | StandRank -> 0
      
    member this.CardValue (suit:Suit, rank:Rank) =
      match suit with
        | Spades   -> this.RankMatch rank
        | Hearts   -> this.RankMatch rank
        | Clubs    -> this.RankMatch rank      
        | Diamonds -> this.RankMatch rank
        | StandSuit -> this.RankMatch rank

    member this.CardExist lst (a,b) =
      if   List.exists (fun x -> x=(a,b)) lst then true
      else false
      
//Checks if theres an Ace of any Suit in a List/Hand
    member this.Ace11Exists lst =
      if List.exists (fun x -> x=(Spades,Ace11)) lst then true
      elif List.exists (fun x -> x=(Hearts,Ace11)) lst then true
      elif List.exists (fun x -> x=(Clubs,Ace11)) lst then true
      elif List.exists (fun x -> x=(Diamonds,Ace11)) lst then true
      else false

  type Deck () =

    member this.DeckCreator =
      List.ofArray (Array.init 52 (fun index -> this.CardNumber (index+1) ))

    member this.CardReturn index lst =
      match (index), lst with
        | 0, x::xs -> x
        | i, x::xs -> this.CardReturn (i-1) xs
        | i, []    -> failwith "index of of range return"
    
    member this.RemoveCard index lst =
      match index, lst with
        | 0, x::xs -> xs
        | i, x::xs -> x::(this.RemoveCard (i-1) xs)
        | i, []    -> failwith "index out of range remove"


        

    member this.CardNumber input =
      match input with
      | 0  -> (StandSuit, StandRank)
      | 1  -> (Spades,Ace11)
      | 2  -> (Spades,Two)
      | 3  -> (Spades,Three)      
      | 4  -> (Spades,Four)
      | 5  -> (Spades,Five)
      | 6  -> (Spades,Six)
      | 7  -> (Spades,Seven)
      | 8  -> (Spades,Eight)
      | 9  -> (Spades,Nine)
      | 10 -> (Spades,Ten)
      | 11 -> (Spades,Jack)
      | 12 -> (Spades,Queen)
      | 13 -> (Spades,King)
      | 14 -> (Hearts,Ace11)
      | 15 -> (Hearts,Two)
      | 16 -> (Hearts,Three)      
      | 17 -> (Hearts,Four)
      | 18 -> (Hearts,Five)
      | 19 -> (Hearts,Six)
      | 20 -> (Hearts,Seven)
      | 21 -> (Hearts,Eight)
      | 22 -> (Hearts,Nine)
      | 23 -> (Hearts,Ten)
      | 24 -> (Hearts,Jack)
      | 25 -> (Hearts,Queen)
      | 26 -> (Hearts,King)
      | 27 -> (Clubs,Ace11)
      | 28 -> (Clubs,Two)
      | 29 -> (Clubs,Three)      
      | 30 -> (Clubs,Four)
      | 31 -> (Clubs,Five)
      | 32 -> (Clubs,Six)
      | 33 -> (Clubs,Seven)
      | 34 -> (Clubs,Eight)
      | 35 -> (Clubs,Nine)
      | 36 -> (Clubs,Ten)
      | 37 -> (Clubs,Jack)
      | 38 -> (Clubs,Queen)
      | 39 -> (Clubs,King)
      | 40 -> (Diamonds,Ace11)
      | 41 -> (Diamonds,Two)
      | 42 -> (Diamonds,Three)      
      | 43 -> (Diamonds,Four)
      | 44 -> (Diamonds,Five)
      | 45 -> (Diamonds,Six)
      | 46 -> (Diamonds,Seven)
      | 47 -> (Diamonds,Eight)
      | 48 -> (Diamonds,Nine)
      | 49 -> (Diamonds,Ten)
      | 50 -> (Diamonds,Jack)
      | 51 -> (Diamonds,Queen)
      | 52  -> (Diamonds,King) 

//Some Unit Tests. All the tested functions work!      
  let Deck = new Deck ()
  let Card = new Card ()
  let mutable deckList = Deck.DeckCreator
  printfn "%A" (Card.CardExist [(Spades,Jack);(Spades,Queen)] (Spades,Jack))
  // printfn "%A\n" deckList
  // printfn "%A\n" (Deck.CardReturn 51 deckList)
  // printfn "%A" (Deck.RemoveCard 51 deckList)

      
