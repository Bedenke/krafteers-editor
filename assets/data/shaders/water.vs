#ifdef GL_ES
precision highp float;
#endif

attribute vec3 a_position;

uniform mat4 u_worldView;
uniform vec2 u_offset;
uniform float u_time;
varying vec2 v_texCoords;
varying vec2 v_texCoords2;

void main()
{
   v_texCoords.x = (a_position.x + u_time) * 0.25;
   v_texCoords.y = (a_position.z + (u_time*0.5)) * 0.25;

   v_texCoords2.x = (a_position.x - (u_time*0.3)) * 0.5;
   v_texCoords2.y = (a_position.z + (u_time*0.06)) * 0.5;

//   float y = sin(a_position.x+a_position.z + (u_time*2.0)) * 0.05;
   gl_Position =  u_worldView * vec4(u_offset.x + a_position.x, a_position.y, u_offset.y + a_position.z, 1);
}