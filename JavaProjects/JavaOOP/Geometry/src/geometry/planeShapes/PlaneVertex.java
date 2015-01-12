package geometry.planeShapes;

import geometry.Vertex;

public class PlaneVertex extends Vertex {
	public PlaneVertex(double col, double row) {
		super(2);
		this.setCol(col);
		this.setRow(row);
	}
	
	@Override
	public double getCol() {
		return super.coordinates[0];
	}
	@Override
	public double getRow() {
		return super.coordinates[1];
	}	
	public void setCol(double value) {
		super.coordinates[0] = value;
	}
	public void setRow(double value) {
		super.coordinates[1] = value;
	}
}
