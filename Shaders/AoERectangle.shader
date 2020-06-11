shader_type canvas_item;

uniform float opacity;

void fragment() {
	vec4 color = texture(TEXTURE, UV);
	COLOR = vec4(0.53, 0.12, 0.12, 1f/opacity);
}