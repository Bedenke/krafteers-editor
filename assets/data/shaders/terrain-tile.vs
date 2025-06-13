#ifdef GL_ES
precision highp float;
#endif

attribute vec4 a_position;
uniform float u_size;
varying float v_height;
varying vec2 v_texCoords;
varying vec4 v_level;

void main()
{
   v_texCoords = vec2(a_position.x / 8.0, a_position.z / 8.0);
   v_height = a_position.w;
   v_level.x = max(min(v_height - 0.2, 0.2), 0.0) * 5.0;
   v_level.y = max(min(v_height - 0.4, 0.2), 0.0) * 5.0;
   v_level.z = max(min(v_height - 0.6, 0.2), 0.0) * 5.0;
   v_level.w = max(min(v_height - 0.8, 0.2), 0.0) * 5.0;
   gl_Position = vec4((a_position.x / u_size * 2.0) - 1.0, (a_position.z / u_size * 2.0) - 1.0, 0, 1);
}