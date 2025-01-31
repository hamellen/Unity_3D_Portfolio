using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackEnd;
using System.Text;

public class UserData
{
    public int level;
    public float hp ;
    public float MaxHp ;
    public int  atk ;
    public int defence ;
    public int speed ;
    public int gold ;
    public int exp;
    public int asked_max_exp;


    public List<int> list_consum=new List<int>();
    public int count_weapon;
    public int count_armor;
}

public class BackendGameData 
{

    

    UserData userdata;
    public UserData UserData
    {
        get {
            return userdata;
        }
    }    
    private string gameDataRowInDate = string.Empty;

    public void GameDataInsert()//최초시작,회원가입
    {

        if (userdata == null)
        {
            userdata = new UserData();
        }

        userdata.level = 1;
        userdata.hp = 100.0f;
        userdata.MaxHp = 100.0f;
        userdata.atk = 40;
        userdata.defence = 5;
        userdata.speed = 5;
        userdata.gold = 100;
        userdata.exp = 0;
        userdata.asked_max_exp = 200;

        userdata.count_weapon = 1;
        userdata.count_armor = 1;

        userdata.list_consum.Add(5);
        userdata.list_consum.Add(5);
        userdata.list_consum.Add(5);
        
        Param param = new Param();
        param.Add("level", userdata.level);
        param.Add("hp", userdata.hp);
        param.Add("MaxHp", userdata.MaxHp);
        param.Add("atk", userdata.atk);
        param.Add("defence", userdata.defence);
        param.Add("speed", userdata.speed);
        param.Add("gold", userdata.gold);
        param.Add("exp", userdata.exp);
        param.Add("asked_max_exp", userdata.asked_max_exp);


        param.Add("count_weapon", userdata.count_weapon);
        param.Add("count_armor", userdata.count_armor);
        param.Add("list_consum", userdata.list_consum);
        var bro = Backend.GameData.Insert("Player_Data", param);

        if (bro.IsSuccess())
        {
            Debug.Log("게임 정보 데이터 삽입에 성공했습니다. : " + bro);

          
        }

    }

    public void GameDataGet()//게임 진입시 데이터 불러오기
    {
        var bro = Backend.GameData.GetMyData("Player_Data", new Where());

        if (bro.IsSuccess())
        {
            Debug.Log("게임 정보 조회에 성공했습니다. : " + bro);


            LitJson.JsonData gameDataJson = bro.FlattenRows(); // Json으로 리턴된 데이터를 받아옵니다.  

            // 받아온 데이터의 갯수가 0이라면 데이터가 존재하지 않는 것입니다.  
            if (gameDataJson.Count <= 0)
            {
                Debug.LogWarning("데이터가 존재하지 않습니다.");
            }
            else
            {
                gameDataRowInDate = gameDataJson[0]["inDate"].ToString(); //불러온 게임 정보의 고유값입니다.  
                if (userdata == null) {
                    userdata = new UserData();
                }
               

                userdata.level = int.Parse(gameDataJson[0]["level"].ToString());
                userdata.hp = float.Parse(gameDataJson[0]["hp"].ToString());
                userdata.MaxHp = float.Parse(gameDataJson[0]["MaxHp"].ToString());
                userdata.atk = int.Parse(gameDataJson[0]["atk"].ToString());
                userdata.defence = int.Parse(gameDataJson[0]["defence"].ToString());
                userdata.speed = int.Parse(gameDataJson[0]["speed"].ToString());
                userdata.gold = int.Parse(gameDataJson[0]["gold"].ToString());
                userdata.exp = int.Parse(gameDataJson[0]["exp"].ToString());
                userdata.asked_max_exp = int.Parse(gameDataJson[0]["asked_max_exp"].ToString());


                userdata.count_weapon = int.Parse(gameDataJson[0]["count_weapon"].ToString());
                userdata.count_armor = int.Parse(gameDataJson[0]["count_armor"].ToString());
                

                for (int i = 0; i < gameDataJson[0]["list_consum"].Count; i++) {//소비재 상품 불러오기 

                    userdata.list_consum.Add( int.Parse(gameDataJson[0]["list_consum"][i].ToString()));
                }


                Manager.DATAMANAGER.player_stat.LEVEL = userdata.level;
                Manager.DATAMANAGER.player_stat.HP = userdata.hp;
                Manager.DATAMANAGER.player_stat.MAXHP = userdata.MaxHp;
                Manager.DATAMANAGER.player_stat.ATTACK = userdata.atk;
                Manager.DATAMANAGER.player_stat.DEFENCE = userdata.defence;
                Manager.DATAMANAGER.player_stat.SPEED = userdata.speed;
                Manager.DATAMANAGER.player_stat.GOLD = userdata.gold;
                Manager.DATAMANAGER.player_stat.EXP = userdata.exp;
                Manager.DATAMANAGER.player_stat.Asked_max_exp = userdata.asked_max_exp;

                Debug.LogWarning("데이터 불어오기 완료");

                
            }


        }
    }

    public void Update_info(Define.PlayerData player_data,int figure=0) //데이터 매니저의 플레이어 스탯 변경후 적용
    {
        //userdata 변경

        switch((int)player_data)
        {

            case 1:
                userdata.hp += figure;
                break;

            case 5:
                userdata.gold += figure;
                break;

            case 7:
                userdata.count_weapon++;
                break;

            case 8:
                userdata.count_armor++;
                break;
        }


        GameDataUpdate();
    }

    public void Update_Consum(int consum_index, int figure) {


        userdata.list_consum[consum_index] = figure;

        GameDataUpdate();
    }


    public void GameDataUpdate()//클라이언트에서의 변경사항이 데이터베이스에 실시간 반영
    {
        if (userdata == null)
        {
            Debug.LogError("서버에서 다운받거나 새로 삽입한 데이터가 존재하지 않습니다. Insert 혹은 Get을 통해 데이터를 생성해주세요.");
            return;
        }

        Param param = new Param();
        param.Add("level", userdata.level);
        param.Add("hp", userdata.hp);
        param.Add("Maxhp", userdata.MaxHp);
        param.Add("atk", userdata.atk);
        param.Add("defence", userdata.defence);
        param.Add("speed", userdata.speed);
        param.Add("gold", userdata.gold);
        param.Add("exp", userdata.exp);
        param.Add("asked_max_exp", userdata.asked_max_exp);

        param.Add("count_weapon", userdata.count_weapon);
        param.Add("count_armor", userdata.count_armor);
        param.Add("list_consum", userdata.list_consum);
        BackendReturnObject bro = null;

        if (string.IsNullOrEmpty(gameDataRowInDate))
        {
            Debug.Log("내 제일 최신 게임 정보 데이터 수정을 요청합니다.");

            bro = Backend.GameData.Update("Player_Data", new Where(), param);
        }
        else
        {
            Debug.Log($"{gameDataRowInDate}의 게임 정보 데이터 수정을 요청합니다.");

            bro = Backend.GameData.UpdateV2("Player_Data", gameDataRowInDate, Backend.UserInDate, param);
        }

        if (bro.IsSuccess())
        {
            Debug.Log("게임 정보 데이터 수정에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("게임 정보 데이터 수정에 실패했습니다. : " + bro);
        }
    }
}
