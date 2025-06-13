#ifdef GL_ES
precision mediump float;
#endif
varying float v_height; 
varying vec3 v_level;
varying vec2 v_texCoords;
varying vec2 v_lightCoords;
uniform sampler2D s_lightMap;
uniform sampler2D s_texture;
uniform vec4 u_ambientColor;
uniform float u_desaturation;
vec4 c;

void main() {
    vec4 outColor = texture2D(s_texture, v_texCoords.xy);
    vec4 lights = texture2D(s_lightMap, v_lightCoords.xy);
	c.r = (outColor.r + u_ambientColor.r) * min(lights.r + u_ambientColor.a, 1.0);
	c.g = (outColor.g + u_ambientColor.g) * min(lights.g + u_ambientColor.a, 1.0);
	c.b = (outColor.b + u_ambientColor.b) * min(lights.b + u_ambientColor.a, 1.0);

	float intensity = (0.3 * c.r) + (0.59 * c.g) + (0.11 * c.b);
	gl_FragColor.r = c.r * (1.0 - u_desaturation) + intensity * u_desaturation;
	gl_FragColor.g = c.g * (1.0 - u_desaturation) + intensity * u_desaturation;
	gl_FragColor.b = c.b * (1.0 - u_desaturation) + intensity * u_desaturation;
	gl_FragColor.a = outColor.a;
}