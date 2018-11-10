/* 
 * Rules for building a new scene: 
 * 
 * - Always include a GlobalController (use the prefab); 
 * 
 * - Add Main Camera and Directional Light Prefabs;
 * 
 * - Add a SceneController (use prefab) - but swap the SceneController script attached with a SceneController instantiation 
 *     specific to the scene you're building (e.g. if building Lab, write a LabSceneController : SceneController script and 
 *     swap that with the SceneController component of the prefab). Also don't forget to add a BackToLabButton if you need to;
 *     
 * - Add a GenomePool (use the prefab);
 * 
 * - Don't forget to add the scene to the Build Settings;
 * 
 * - To render the floor, create a new tile palette with the sprites you want to use, and then make a Tilemap for the scene.
 *
 * */