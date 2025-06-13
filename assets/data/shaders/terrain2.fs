#ifdef GL_ES
precision mediump float;
#endif

varying float v_height;
varying vec4 v_level;
varying vec2 v_texCoords;
varying vec2 v_lightCoords;

uniform vec4 u_ambientColor;
uniform float u_desaturation;

uniform sampler2D s_lightMap;
uniform sampler2D s_texture0;
uniform sampler2D s_texture1;
uniform sampler2D s_texture2;
uniform sampler2D s_texture3;
uniform sampler2D s_texture4;

vec4 c;
void main() {
    vec4 tex0 = texture2D(s_texture0, v_texCoords.xy);
    vec4 tex1 = texture2D(s_texture1, v_texCoords.xy);
    vec4 tex2 = texture2D(s_texture2, v_texCoords.xy);
    vec4 tex3 = texture2D(s_texture3, v_texCoords.xy);
    vec4 tex4 = texture2D(s_texture4, v_texCoords.xy);

	vec4 outColor = mix(tex0, tex1, v_level.x);
	outColor = mix(outColor, tex2, v_level.y);
	outColor = mix(outColor, tex3, v_level.z);
	outColor = mix(outColor, tex4, v_level.w);

    vec4 lights = texture2D(s_lightMap, v_lightCoords.xy);
    c.r = (outColor.r) * min(lights.r + u_ambientColor.r + u_ambientColor.a, 1.0);
    c.g = (outColor.g) * min(lights.g + u_ambientColor.g + u_ambientColor.a, 1.0);
    c.b = (outColor.b) * min(lights.b + u_ambientColor.b + u_ambientColor.a, 1.0);

    float intensity = ((0.3 * c.r) + (0.59 * c.g) + (0.11 * c.b)) * u_desaturation;
    gl_FragColor.r = c.r * (1.0 - u_desaturation) + intensity;
    gl_FragColor.g = c.g * (1.0 - u_desaturation) + intensity;
    gl_FragColor.b = c.b * (1.0 - u_desaturation) + intensity;
    gl_FragColor.a = outColor.a;
}