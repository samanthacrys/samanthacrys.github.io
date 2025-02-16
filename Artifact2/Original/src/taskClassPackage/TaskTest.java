package taskClassPackage;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;


public class TaskTest {

	
	//Tests that a task is created.
	@Test
	public void TaskCreationTest()
	{
		
		Task task = new Task("1", "Task Name", "Task Description");
		
		assertEquals("1", task.GetTaskID());
		assertEquals("Task Name", task.GetName());
		assertEquals("Task Description", task.GetDesc());
	}
	
	//Tests that the task ID is less than 10 in length.
	@Test
	public void TaskIDLengthTestLessThanTest()
	{
		Task task = new Task("Task1", "NewTask", "New Description");
		
		assertTrue(task.GetTaskID().length() < 10);
	}
	
	//Tests that the task ID is equal to 10 in length.
	@Test
	public void TaskIDLengthEqualsTest()
	{
		
		Task task = new Task("NewTask123", "NewTask", "New Description");
		
		assertEquals(10, task.GetTaskID().length());
	}
	
	//Tests that the task ID is not null.
	@Test
	public void TaskIDNotNullTest()
	{
		
		Task task = new Task("Task1", "NewTask", "New Description");
		
		assertNotNull(task.GetTaskID());
	}
	
	//Tests the name to make sure it is a valid name.
	@Test
	public void InvalidNameTest()
	{
		assertThrows(IllegalArgumentException.class, () -> {
			new Task("1", null, "Task Description");
		});
		
		assertThrows(IllegalArgumentException.class, () -> {
			new Task("1", "This is way too long and makes sure it's valid.", "Task Description");
		});
	}
	
	@Test
	public void InvalidDescTest()
	{
		assertThrows(IllegalArgumentException.class, () -> {
			new Task("1", "Task Name", null);
		});
		
		assertThrows(IllegalArgumentException.class, () -> {
			new Task("1", "Task Name", "This description is definitely too long for this area and should only be 50 characters.");
		});
	}
}
