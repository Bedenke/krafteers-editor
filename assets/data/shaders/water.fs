#ifdef GL_ES
precision mediump float; 
#endif
varying vec2 v_texCoords;
varying vec2 v_texCoords2;
uniform sampler2D u_texture;
uniform vec4 u_ambientColor;
uniform float u_desaturation;
vec4 c;

void main()
{
    vec4 outColor1 = texture2D(u_texture, v_texCoords.xy);
	vec4 outColor2 = texture2D(u_texture, v_texCoords2.xy);

	vec4 outColor = mix(outColor1, outColor2, 0.5);
	c.r = (outColor.r + u_ambientColor.r) * u_ambientColor.a;
	c.g = (outColor.g + u_ambientColor.g) * u_ambientColor.a;
	c.b = (outColor.b + u_ambientColor.b) * u_ambientColor.a;

	float intensity = ((0.3 * c.r) + (0.59 * c.g) + (0.11 * c.b)) * 0.25;
	gl_FragColor.r = c.r * (1.0 - u_desaturation) + intensity * u_desaturation;
	gl_FragColor.g = c.g * (1.0 - u_desaturation) + intensity * u_desaturation;
	gl_FragColor.b = c.b * (1.0 - u_desaturation) + intensity * u_desaturation;
	gl_FragColor.a = 0.3;
}