shader_type canvas_item;

uniform bool changing_class;

void fragment() {
	vec4 color = texture(TEXTURE, UV);
    if(changing_class){
	    COLOR = vec4(1, 1, 1, color.a);
	}
	else{
	    COLOR = color;
	}
}