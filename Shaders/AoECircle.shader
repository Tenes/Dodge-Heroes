shader_type canvas_item;

uniform float opacity;
uniform vec4 color_to_transparent: hint_color;
uniform vec4 transparent_color: hint_color;

void fragment() {
	vec4 curr_color = texture(TEXTURE, UV);

    if (curr_color == color_to_transparent){
        COLOR = transparent_color;
    }else{
        COLOR = vec4(0.53, 0.12, 0.12, 1f/opacity);
    }
}