Feature: ComparePrices

@mytag
Scenario: Get Cube and other Information from Cubeless
	Given I instantiate a CubeObject
	When I call the method GetPriceCubeless<Cube>
	Then the seller is Cubeless
	And the price contains <Number>
	And shipping time contains <Lieferzeit>
Examples:
	| Cube              | Number | Lieferzeit |
	| Tornado V2        | true   | true       |
	| RandomLettersABCQ | false  | false      |
	| YJ MGC 4x4 M      | true   | true       |