attribute vec3 a_position;
attribute vec4 a_color;
attribute vec4 a_emission;
attribute vec2 a_texCoord;

uniform mat4 u_projectionViewMatrix;
uniform vec3 u_light;

varying vec4 v_color;
varying vec4 v_emission;
varying vec2 v_texUV;
varying float v_texIndex;
varying vec2 v_lightCoords;

void main()
{
	v_texUV = a_texCoord;
	v_emission = a_emission;
	v_color = a_color;
    v_lightCoords = vec2(((a_position.x-u_light.x) / u_light.z), ((a_position.z-u_light.y) / u_light.z));
    gl_Position =  u_projectionViewMatrix * vec4(a_position, 1);
}