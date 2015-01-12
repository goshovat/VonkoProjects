package oneLevShop.products;

import oneLevShop.AgeRestriction;
import oneLevShop.interfaces.Buyable;

public abstract class Product implements Buyable {
	private String name; 
	private double price;
	private int quantity;
	private AgeRestriction ageRestriction;
	
	public Product
		(String name, double price, int quantity, AgeRestriction ageRestriction) {
		this.setName(name);
		this.setPrice(price);
		this.setQuantity(quantity);
		this.setAgeRestriction(ageRestriction);
	}

	public String getName() {
		return name;
	}
	public double getPrice() {
		return price;
	}	
	public int getQuantity() {
		return this.quantity;
	}	
	public AgeRestriction getAgeRestriction() {
		return ageRestriction;
	}	
	private void setName(String name) {
		if (name.isEmpty())
			throw new IllegalArgumentException
				("Error! Product name cannot be empty");
		
		this.name = name;
	}
	private void setPrice(double price) {
		if (price < 0)
			throw new IllegalArgumentException
				("Error! Product price cannot be negative");
		
		this.price = price;
	}	
	public void setQuantity(int quantity) {
		if (price < 0)
			throw new IllegalArgumentException
				("Error! Product quantity cannot be negative");
		
		this.quantity = quantity;
	}
	private void setAgeRestriction(AgeRestriction ageRestriction) {
		this.ageRestriction = ageRestriction;
	}
}
