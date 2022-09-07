README
================================

Contents
--------------------------------
About
Installation Instructions
Usage Instructions
Requirements
Support
Demo Material Asset Licensing


About
--------------------------------
Easy Ghost Shader is a simple, lightweight ghost effect shader. It enables you to easily convert existing characters or environment to ghosts or spirits. This is an opaque shader, so all objects will be correctly depth tested and integrated into your scene.

Easy Ghost includes Lit and Unlit shader variants. These are modeled after Unity's built-in Lit and Unlit shader variants, so it is easy to convert an existing Lit or Unlit material to a Ghost-ified version.

You can view a demo of the shader in action on itch: https://occasoftware.itch.io/easy-ghost-shader

You can also choose to enable two parameters that make your ghost effect more dynamic. One parameter enables the ghost effect to ripple over time, and a second parameter enables the falloff of the ghost effect to increase and decrease over time.

The Lit shader variant includes the following parameters
# Albedo Map
# Albedo Color
# Normal Map
# Metallic (R) and Smoothness (A) Map
# Occlusion Map
# Inner Color
# Outer Color
# Falloff
# Falloff Offset Frequency
# Noise Offset Frequency
# Enable Noise Layer
# Enable Falloff Offset Over Time

The Unlit shader variant includes the following parameters
# Albedo Map
# Albedo Color
# Inner Color
# Outer Color
# Normal Map
# Falloff
# Falloff Offset Frequency
# Noise Offset Frequency
# Enable Noise Layer
# Enable Falloff Offset Over Time


Installation Instructions
--------------------------------
1. Import the Easy Ghost asset into your project.
2. Apply one of the included materials from ~/Ghost Shader/Materials/ to your character or object in scene.
3. Configure the material as needed, such as adding Albedo Maps, Normal Maps, etc.


Usage Instructions
--------------------------------
1. Simply apply the material to the target object and configure in the Inspector.


Requirements
--------------------------------
This asset is designed for Unity 2020.3 Universal Render Pipeline. This asset is not guaranteed to work on other versions of Unity. This asset will not work on the Built-In Render Pipeline or the High Definition Render Pipeline.


Support
--------------------------------
If you're not happy, I'm not happy.
Please contact me at occasoftware@gmail.com for any support.


Demo Material Asset Licensing
--------------------------------
Contains assets from ambientCG.com, licensed under CC0 1.0 Universal.

