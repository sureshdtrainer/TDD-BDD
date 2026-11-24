Feature: Order discounts

	As a shopper
	I want eligible orders to receive discount
	so that I pay the correct final amount

Scenario: Order below discount threshold
	Given an order amount of 80
	When the final amount is calculated
	Then the final amount should be 80

Scenario: Order qualites for first discount band
	Given an order amount of 200
	When the final amount is calculated
	Then the final amount should be 180

Scenario: Order qualifies for second discount band
	Given an order amount of 600
	When the final amount is calculated
	Then the final amount should be 480