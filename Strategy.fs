// Strategy.fs
namespace SimpleJack

open SimpleJack 

module Strategy =

//Strategy Super-Class, uses predicates.
  type Strategy () =
    member this.StrategyInit p x =
        p x
            
  type Strategy1 () =
    inherit Strategy ()
    member this.Strat1 x =
      this.StrategyInit (fun x -> x <= 15) x

  type Strategy2 () =
    inherit Strategy ()
    member this.Strat2 x =
      this.StrategyInit (fun x -> x <= 17) x

  type Strategy3 () =
    inherit Strategy ()
    member this.Strat3 x =
      this.StrategyInit (fun x -> x <= 19) x

  type Strategy4 () =
    inherit Strategy ()
    member this.Strat4 x =
      this.StrategyInit (fun x -> x < 50) x

  type Strategy5 () =
    inherit Strategy ()
    member this.Strat5 x =
      this.StrategyInit (fun x -> CardDeck.Card.Ace11Exists x ) x

