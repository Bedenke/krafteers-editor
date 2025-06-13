#ifdef GL_ES
precision mediump float;
#endif
varying float v_height; 
varying vec4 v_level;
varying vec2 v_texCoords;
uniform sampler2D s_texture1;
uniform sampler2D s_texture2;
uniform sampler2D s_texture3;
uniform sampler2D s_texture4;
uniform sampler2D s_texture5;

void main() {
    vec4 tex1 = texture2D( s_texture1, v_texCoords.xy);
    vec4 tex2 = texture2D( s_texture2, v_texCoords.xy);
    vec4 tex3 = texture2D( s_texture3, v_texCoords.xy);
    vec4 tex4 = texture2D( s_texture4, v_texCoords.xy);
    vec4 tex5 = texture2D( s_texture5, v_texCoords.xy);
	gl_FragColor = mix(tex1, tex2, v_level.x);
	gl_FragColor = mix(gl_FragColor, tex3, v_level.y);
	gl_FragColor = mix(gl_FragColor, tex4, v_level.z);
	gl_FragColor = mix(gl_FragColor, tex5, v_level.w);
}