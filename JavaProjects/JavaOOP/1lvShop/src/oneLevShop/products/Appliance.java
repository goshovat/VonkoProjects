package oneLevShop.products;

import oneLevShop.AgeRestriction;

public class Appliance extends ElectronicsProduct {
	private static final int APPLIANCE_GUARANTEE = 6;

	public Appliance(String name, double price, int quantity,
			AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, APPLIANCE_GUARANTEE);
	}
	
	@Override
	public double getPrice() {
		if (super.getQuantity() < 50)
			return super.getPrice() * 1.05;
		else
			return super.getPrice();
	}	
	@Override
	public String toString() {
		return String.format(
				"Appliance - Name: %.2f, Price: %.2f, Quantity: %.2f, "
				+ "Age Restricton: %.2f, Guarantee Period: %.2f",
				super.getName(), super.getPrice(), super.getQuantity(), 
				super.getAgeRestriction(), this.getGuaranteePeriod());
	}
}
