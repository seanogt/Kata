Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Add two numbers
	Given A new instance of my calculator
	When I press pass an <arbiturturyListOfNumbers>
	Then the result should be <expectedResult>
Examples: 
| arbiturturyListOfNumbers | expectedResult |
|                          | 0              |
| 1                        | 1              |
| 1,2                      | 3              |
| 1,4,2,5,7                | 19             |
| 1,1001,2,3               | 6              |

Scenario: Passing a list of numbers that contain new line characters
Given A new instance of my calculator
When the following string is passed to the calculator 
"""
1
2,3
"""
Then the result should be 6

Scenario: Passing a variable delimiter
Given A new instance of my calculator
When the following string is passed to the calculator
"""
//;
1;3;5
"""
Then the result should be 9

Scenario: Delimiters can be longer than a single character
Given A new instance of my calculator
When the following string is passed to the calculator
"""
//***
1***3***5
"""
Then the result should be 9

Scenario: The values passed can have multiple delimiters
Given A new instance of my calculator
When the following string is passed to the calculator
"""
//[*][%]
1*2%3
"""
Then the result should be 6

Scenario: The values passed can have multiple delimiters of varying length
Given A new instance of my calculator
When the following string is passed to the calculator
"""
//[*][%%]
1*2%%3
"""
Then the result should be 6

Scenario: Passing negative values causes an exception
Given A new instance of my calculator
When the following string is passed to the calculator
"""
1,-4,-5,5
"""
Then an exception should be thrown detailing the negative values