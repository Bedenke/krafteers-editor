#ifdef GL_ES
precision highp float;
#endif

attribute vec4 a_position;
uniform mat4 u_worldView;
uniform vec4 u_ambientColor;
uniform vec3 u_light;
uniform vec2 u_offset;
uniform float u_size;
varying float v_height;
varying vec2 v_texCoords;
varying vec2 v_lightCoords;
varying vec3 v_level;
void main()
{
   v_texCoords = vec2(a_position.x / u_size, a_position.z / u_size);
   v_lightCoords = vec2(((a_position.x-u_light.x) / u_light.z), ((a_position.z-u_light.y) / u_light.z));
   v_height = a_position.w;
   v_level.x = min(v_height * 2.0,1.0);
   v_level.y = min(max(v_height-0.5,0.0) * 4.0, 1.0);
   v_level.z = min(max(v_height-0.75,0.0) * 4.0, 1.0);
   gl_Position = u_worldView * vec4(u_offset.x + a_position.x, a_position.y, u_offset.y + a_position.z, 1);
}