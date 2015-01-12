package oneLevShop.products;

import oneLevShop.AgeRestriction;

public class Computer extends ElectronicsProduct {
	private static final int COMPUTER_GUARANTEE = 24;
	
	public Computer(String name, double price, int quantity,
			AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, COMPUTER_GUARANTEE);
	}
	
	@Override
	public double getPrice() {
		if (super.getQuantity() > 1000)
			return super.getPrice() * 0.95;
		else
			return super.getPrice();
	}
	@Override
	public String toString() {
		return String.format(
				"Computer - Name: %.2f, Price: %.2f, Quantity: %.2f, "
				+ "Age Restricton: %.2f, Guarantee Period: %.2f",
				super.getName(), super.getPrice(), super.getQuantity(), 
				super.getAgeRestriction(), this.getGuaranteePeriod());
	}
}
