package geometry.planeShapes;

import java.util.ArrayList;
import java.util.Arrays;

import geometry.Shape;
import geometry.Vertex;
import geometry.Interfaces.AreaMeasurable;
import geometry.Interfaces.PerimeterMeasurable;

public abstract class PlaneShape extends Shape
implements PerimeterMeasurable, AreaMeasurable  {
	
	public PlaneShape(PlaneVertex[] verticies) {	
		super(new ArrayList<Vertex>(
				Arrays.asList(verticies)));	
	}
	
	public double getPerimeter() {
		return 0.0;
	}
	
	public double getArea() {
		return 0.0;
	}
}
