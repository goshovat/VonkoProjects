package geometry.spaceShapes;

import java.util.ArrayList;
import java.util.Arrays;

import geometry.Shape;
import geometry.Vertex;
import geometry.Interfaces.AreaMeasurable;
import geometry.Interfaces.VolumeMeasurable;

public abstract class SpaceShape extends Shape
implements AreaMeasurable, VolumeMeasurable {
	
	public SpaceShape(SpaceVertex[] verticies) {
		super(new ArrayList<Vertex>(
				Arrays.asList(verticies)));
	}
	
	public double getArea() {
		return 0;
	}	
	public double getVolume() {
		return 0;
	}
}
