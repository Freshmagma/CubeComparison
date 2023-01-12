Feature: ComparePrices

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

Scenario: Get Cube and other Information from Fabitasia
	Given I instantiate a CubeObject
	When I call the method GetPriceFabitasia<Cube>
	Then the seller is Fabitasia
	And the price contains <Number>
Examples:
	| Cube              | Number |
	| Tornado V2        | true   |
	| RandomLettersABCQ | false  |
	| YJ MGC 4x4 M      | true   |

Scenario: Get Cube and other Information from TheCubicle
	Given I instantiate a CubeObject
	When I call the method GetPriceTheCubicle<Cube>
	Then the seller is TheCubicle
	And the price contains <Number>
Examples:
	| Cube              | Number |
	| Tornado V2        | true   |
	| RandomLettersABCQ | false  |
	| YJ MGC 4x4 M      | true   |

Scenario: Cube can't be found
	Given I instantiate a CubeObject
	When get a non existing Cube from <Shop>
	Then I get the the message Cube not found
Examples:
	| Shop       |
	| Cubeless   |
	| Fabitasia  |
	| TheCubicle |