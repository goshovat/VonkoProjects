package oneLevShop.products;

import java.util.Calendar;

import oneLevShop.AgeRestriction;
import oneLevShop.interfaces.Expirable;

public class FoodProduct extends Product 
implements Expirable {

	private Calendar expirationDate;
	
	public FoodProduct
	(String name, double price, int quantity, 
	AgeRestriction ageRestriction, Calendar expirationDate) {
		super(name, price, quantity, ageRestriction);
		this.expirationDate = expirationDate;
	}
	
	@Override
	public double getPrice() {
		Calendar now = Calendar.getInstance(); 
		long difference = expirationDate.getTimeInMillis()
				- now.getTimeInMillis();
		long days = difference / (1000 * 60 * 60 * 24);
		
		if (days < 15)
			return 0.7 * super.getPrice();
		else 
			return super.getPrice();
	}	
	@Override
	public Calendar getExpirationDate() {
		return this.expirationDate;
	}
	@Override
	public String toString() {
		return String.format(
				"Food product - Name: %.2f, Price: %.2f, Quantity: %.2f, "
				+ "Age Restricton: %.2f, Expiry Date: %.2f",
				super.getName(), super.getPrice(), super.getQuantity(), 
				super.getAgeRestriction(), this.getExpirationDate());
	}
}
