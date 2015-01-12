package geometry;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import geometry.planeShapes.Circle;
import geometry.planeShapes.PlaneShape;
import geometry.planeShapes.Rectangle;
import geometry.planeShapes.Triangle;
import geometry.spaceShapes.Cuboid;
import geometry.spaceShapes.SpaceShape;
import geometry.spaceShapes.Sphere;
import geometry.spaceShapes.SquarePyramid;

public class GeometryTester {
	
	public static void main(String[] args) {
		
		//create some two-dimensional shapes
		PlaneShape circle = new Circle(3, 5, 20);
		PlaneShape rectangle = new Rectangle(5, 6, 3, 30);
		PlaneShape triangle = new Triangle(2, -1, 3, 5, 7, -10);
		
		//create some three-dimensional shapes
		SpaceShape cuboid = new Cuboid(1, 0, 3, 2, 4, 2);
		SpaceShape sphere = new Sphere(0, 0, 2, 5);
		SpaceShape squarePyramid = new SquarePyramid(3, 8, 2, 4, 7);
		
		//create and filter the arrays of shapes
		SpaceShape[] spaceShapes = new SpaceShape[] {cuboid, sphere, squarePyramid};
		List<SpaceShape> shapeList = Arrays.asList(spaceShapes).stream()
				.filter(s -> s instanceof SpaceShape).map(s -> (SpaceShape) s)
				.filter(v -> v.getVolume() > 20).collect(Collectors.toList());

		System.out.println();		
		for (SpaceShape shape : shapeList) {
			System.out.println(shape);
			System.out.println(shape.getVolume());
		}
		
		PlaneShape[] planeShapes = new PlaneShape[] {circle, rectangle, triangle};	
		
		Comparator<PlaneShape> comparatorByPerimeter = (
				PlaneShape s1, PlaneShape s2) -> {
			double diff = s1.getPerimeter() - s2.getPerimeter();
			if (diff < 0) {
				return -1;
			}

			if (diff > 0) {
				return 1;
			}

			return 0;
		};
		
		List<PlaneShape> SortedShapes = Arrays.asList(planeShapes).stream()
				.filter(s -> s instanceof PlaneShape)
				.map(s -> (PlaneShape) s)
				.sorted(comparatorByPerimeter)
				.collect(Collectors.toList());
		
		System.out.println();
		for (PlaneShape shape : SortedShapes) {
			System.out.println(String.format("Perimeter: %.2f", shape.getPerimeter()));
			System.out.println(shape);
			System.out.println();
		}
	}
}
