using Godot;

public partial class Player : CharacterBody2D
{
	[Export] private float MoveSpeed = 200f;

	private AnimatedSprite2D animatedsprite;

	public override void _Ready()
	{
		animatedsprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	private void HandleAnimation(Vector2 direction){

		if(direction == Vector2.Zero)
		{
			animatedsprite.Stop();
			return;
		}

		string anim = "";

		if(direction.X !=0){
			anim=direction.X>0 ? "walkright" : "walkleft";
		}
		else if(direction.Y != 0)
		{
			anim=direction.Y>0? "walkdown" : "walkup";
		}

		if(animatedsprite.Animation != anim){
			animatedsprite.Play(anim);
		}
	}

	private void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		Velocity = inputDirection * MoveSpeed;

		HandleAnimation(inputDirection);
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
