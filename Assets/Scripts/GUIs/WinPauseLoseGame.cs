using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinPauseLoseGame : MonoBehaviour {

	public GameObject MainMenu;
	int prev_pausestate;

	Sprite NormalSpeed,FastSpeed;
	public void Start(){
		NormalSpeed= (Sprite) Resources.Load <Sprite> ("InGameGUI/play_button");
		FastSpeed= (Sprite) Resources.Load <Sprite> ("InGameGUI/faster_button");
	}

	public void QuitToMain(){
		SoundControl.PlaySFX(GlobalData.SFX_Paths[0], false, true, true);
		
		Destroy_InGameObjects();
		MainMenu.GetComponent<ButtonMainMenu>().GoToHome();
		Disable_All_InGame_GUIs();
		//this.gameObject.SetActive(false);
		PlayerData.current_score = 0;
		SoundControl.PlayMusic(GlobalData.Music_Paths[0], true);
	}
	
	public void RestartGame(){
		SoundControl.PlaySFX(GlobalData.SFX_Paths[0], false, true, true);
		
		Destroy_InGameObjects();
		Disable_All_InGame_GUIs();
		PlayerData.current_score = 0;
		MainMenu.transform.FindChild("LevelsMenu").GetComponent<LevelsMenu>().StartLevel(GlobalData.current_level);
	}
	
	public void NextGame(){
		SoundControl.PlaySFX(GlobalData.SFX_Paths[0], false, true, true);
		
		Destroy_InGameObjects();
		Disable_All_InGame_GUIs();


		if(GlobalData.current_level<10)
			MainMenu.transform.FindChild("LevelsMenu").GetComponent<LevelsMenu>().StartLevel(GlobalData.current_level+1);
		else
		{
			end_anim_tr =GameObject.Find("Canvas").transform.FindChild("InGame").gameObject.transform.FindChild("EndAnim");
			end_anim_tr.gameObject.SetActive(true);

			GameObject.Find("InGame").gameObject.transform.FindChild("EndAnim").gameObject.transform.FindChild("Screen01").gameObject.transform.FindChild("Player").gameObject.GetComponent<Animator>().SetInteger("player", PlayerData.picked_playerid);
			doingendanim=true;
			end_anim_tr.GetComponent<Button>().onClick.RemoveAllListeners();
			end_anim_tr.GetComponent<Button>().onClick.AddListener(()=>{
				end_anim_tr.gameObject.SetActive(false);
				doingendanim=false;
				GameObject.Find("Canvas").transform.FindChild("InGame").gameObject.transform.FindChild("EndAnim").gameObject.SetActive(false);
				//Win();
				MainMenu.transform.FindChild("LevelsMenu").GetComponent<LevelsMenu>().StartLevel(GlobalData.current_level+1);

				//Todo if is last game.....
			});
			end_anim = end_anim_tr.GetComponent<Animator>();
		}

	}

	public void PauseGame(){
		SoundControl.PlaySFX(GlobalData.SFX_Paths[0], false, true, true);
		GameObject UI_Tutorial = GameObject.Find("Canvas").transform.FindChild("InGame").gameObject.transform.FindChild("Tutorial").gameObject;
		if(PlayerData.level_state == 0){
			transform.FindChild("PauseMenu").gameObject.SetActive(true);
			PlayerData.level_state = 2;
		}else if(PlayerData.level_state==2){
			transform.FindChild("PauseMenu").gameObject.SetActive(false);
			if(!UI_Tutorial.activeSelf || GlobalData.TutCanBuildFree)
				PlayerData.level_state = 0;
		}
	}


	private void Destroy_InGameObjects(){
		GameObject level = GameObject.FindGameObjectWithTag("TD_Level");
		level.transform.parent = null;
		Destroy (level);
	}

	private void Disable_All_InGame_GUIs(){
		int total_menus = this.transform.childCount;
		for(int i=0; i<total_menus; i++){
			this.transform.GetChild(i).gameObject.SetActive(false);
		}

		this.transform.FindChild("TD").transform.FindChild("TowerSpotsGUIs").transform.FindChild("pnl_info").gameObject.SetActive(false);
		int total_towerbuttonsmenus = this.transform.FindChild("TD").transform.FindChild("TowerSpotsGUIs").transform.FindChild("tbtns").childCount;
		for(int i=0; i<total_towerbuttonsmenus; i++){
			this.transform.FindChild("TD").transform.FindChild("TowerSpotsGUIs").transform.FindChild("tbtns").transform.GetChild(i).gameObject.SetActive(false);
		}
	}

	int current_speed = 0;
	float[] game_speeds = new float[]{1, 5}; 
	public void SpeedUp(){
		current_speed++;
		if(current_speed>=game_speeds.Length){
			current_speed-=1;
			this.transform.FindChild("TD").transform.FindChild("btn_speedup").GetComponent<Image>().sprite=FastSpeed;
		}
		Time.timeScale = game_speeds[current_speed];
	}

	public void SpeedDown(){
		current_speed = 0;
		Time.timeScale = game_speeds[current_speed];
	}

 
	void OnApplicationPause (bool pause)
	{
		if(pause)
		{
			if(GameObject.FindGameObjectWithTag("TD_Level") != null)
			{
				transform.FindChild("PauseMenu").gameObject.SetActive(true);
				PlayerData.level_state = 2;
			}
			// we are in background
		}
	}

	bool doingendanim=false;
	Animator end_anim;
	Transform end_anim_tr;
	void Update(){
		if(doingendanim)
		{
			if(end_anim!=null){
				if(end_anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.End")){
					end_anim_tr.gameObject.SetActive(false);
					doingendanim=false;
					GameObject.Find("Canvas").transform.FindChild("InGame").gameObject.transform.FindChild("EndAnim").gameObject.SetActive(false);
					//Win();
					MainMenu.transform.FindChild("LevelsMenu").GetComponent<LevelsMenu>().StartLevel(GlobalData.current_level+1);
				}
			}
		}
	}

}
