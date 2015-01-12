package geometry;

public abstract class Vertex {
	protected double[] coordinates;
	
	public Vertex(int numberCoordinates) {
		this.coordinates = new double[numberCoordinates];
	}
	
	public double getCol() {
		return 0;
	}
	public double getRow() {
		return 0;
	}
}
