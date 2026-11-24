Feature: Order discounts

	As a shopper
	I want eligible orders to receive discount
	so that I pay the correct final amount

Scenario Outline: Calculate discount based on order amount
	Given an order amount of <amount>
	When the final amount is calculated
	Then the final amount should be <finalAmount>

	Examples:
      | amount | finalAmount |
      | 80     | 80          |
      | 100    | 90          |
      | 200    | 180         |
      | 500    | 400         |
      | 600    | 480         |
