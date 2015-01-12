package oneLevShop;

import java.util.Calendar;
import oneLevShop.interfaces.Expirable;
import oneLevShop.products.Product;

public class PurchaseManager {
	
	public static void processPurchase(Customer customer, Product product) {
		if(product.getQuantity() == 0)
			throw new RuntimeException("The product is out of stock!");
		
		if (product instanceof Expirable) {
			Expirable expirableProduct = (Expirable)product;
			Calendar now = Calendar.getInstance(); 
			long difference = expirableProduct.getExpirationDate().getTimeInMillis()
					- now.getTimeInMillis();
			long days = difference / (1000 * 60 * 60 * 24);
			
			if (days <= 0)
				throw new RuntimeException("The product is expired!");
		}
		
		if (customer.getBalance() < product.getPrice())
			throw new RuntimeException("You do not have enough money to buy this product!");
		
		if (product.getAgeRestriction() != AgeRestriction.None) {
			if (product.getAgeRestriction() == AgeRestriction.Adult && 
					customer.getAge() <= 18)
				throw new RuntimeException("You are too young to buy this product!");
			
			if (product.getAgeRestriction() == AgeRestriction.Teenage && 
					customer.getAge() > 19)
				throw new RuntimeException("You are too old to buy this product!");
			
			//process the purchase
			customer.setBalance(customer.getBalance() - product.getPrice());
			product.setQuantity(product.getQuantity() - 1);
		}
	}
}
