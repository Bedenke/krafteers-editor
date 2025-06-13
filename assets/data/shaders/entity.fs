#ifdef GL_ES
	precision mediump float;
#endif

uniform sampler2D u_lightMap;
uniform sampler2D u_texture;
uniform float u_desaturation;
uniform vec4 u_ambientColor;

varying vec4 v_color;
varying vec4 v_emission;
varying vec2 v_texUV;
varying vec2 v_lightCoords;

vec4 c;

void main()
{
	vec4 outColor = texture2D(u_texture, v_texUV) * v_color;

    vec4 lights = texture2D(u_lightMap, v_lightCoords.xy);
    c.r = (outColor.r) * min((lights.r + u_ambientColor.r + u_ambientColor.a), 1.0);
    c.g = (outColor.g) * min((lights.g + u_ambientColor.g + u_ambientColor.a), 1.0);
    c.b = (outColor.b) * min((lights.b + u_ambientColor.b + u_ambientColor.a), 1.0);

	float sat = ((0.3 * c.r) + (0.59 * c.g) + (0.11 * c.b)) * u_desaturation;
	float inv_sat = (1.0 - u_desaturation);
	gl_FragColor.r = max(c.r * inv_sat + sat, v_emission.r * outColor.r);
	gl_FragColor.g = max(c.g * inv_sat + sat, v_emission.g * outColor.g);
	gl_FragColor.b = max(c.b * inv_sat + sat, v_emission.b * outColor.b);
	gl_FragColor.a = outColor.a;
}