shader_type canvas_item;

uniform bool blinking;
uniform vec4 blink_color;

void fragment() {
	vec4 color = texture(TEXTURE, UV);
    if(blinking){
	    COLOR = vec4(blink_color.x, blink_color.y, blink_color.z, color.a);
	}
	else{
	    COLOR = color;
	}
}