package geometry.spaceShapes;

public class Cuboid extends SpaceShape {

	private double width;
	private double height;
	private double depth;
	
	public Cuboid
	(double col, double row, double layer, double width, double height, double depth) {
		super(new SpaceVertex[] 
				{new SpaceVertex(col, row, layer)} );
		this.setWidth(width);
		this.setDepth(depth);
		this.setDepth(depth);
	}
	
	public double getCol() {
		return super.vertices.get(0).getCol();
	}
	public double getRow() {
		return super.vertices.get(0).getRow();
	}	
	public double getWidth() {
		return this.width;
	}
	public double getHeight() {
		return this.height;
	}
	public double getDepth() {
		return this.depth;
	}	
	public void setWidth(double width) {
		if (width < 0)
			throw new IllegalArgumentException("The width of a cuboid cannot be negative!");
		
		this.width = width;
	}
	public void setHeight(double height) {
		if (height < 0)
			throw new IllegalArgumentException("The height of a cuboid cannot be negative!");
		
		this.height = height;
	}
	public void setDepth(double depth) {
		if (width < 0)
			throw new IllegalArgumentException("The depth of a cuboid cannot be negative!");
		
		this.depth = depth;
	}

	@Override
	public double getArea() {
		return 2* this.width * this.height + 
				2 * this.width * this.depth +
				2 * this.height * this.depth;
	}

	@Override
	public double getVolume() {
		return this.width * this.height * this.depth;
	}
	
	@Override
	public String toString() {
		return String.format("Cuboid - vertex: %.2f, %.2f, width: %.2f, height: %.2f, depth: %.2f",
				this.getCol(), this.getRow(), this.getWidth(), this.getHeight(), this.getDepth());
	}
}
