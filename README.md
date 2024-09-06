# KeepAttackRPG
 방치형 모바일 게임의 구조를 띈 연습 프로젝트입니다.
 FireBase를 통한 기본적인 로그인, 회원가입 기능을 추가해 보았습니다.
 
 dev-firebase 브랜치에서는 firebase의 기능이 구현되어있지만, 대용량의 파일 commit이 되지 않아 실행되지는 않습니다.
 
 main에는 firebase기능을 제외하고 구현되어있습니다.

 
 ### 개발환경 
 - Unity2022.3.21f1
 - Microsoft Visual Studio Community 2022 버전 17.8.4
 
## 시연영상
https://github.com/user-attachments/assets/d9e24ea8-addb-4be8-ba16-642dcaf968b1

## 와이어프레임
![image](https://github.com/user-attachments/assets/b3b6425b-4c70-471e-994a-2844006af554)


## 구현기능
- FireBase를 통한 로그인, 회원가입 기능
- Coroutine을 통한 플레이어,몬스터 행동 제어
- Physics.Overlap을 이용한 적 콜라이더 확인 및 메서드 실행
 ```C#
 MonsterCollider = Physics2D.OverlapCircle (this.gameObject.transform.position,radius,1<<6);
```

- 애니메이션 이벤트를 활용한 적 공격 이벤트 실행
 ![image](https://github.com/user-attachments/assets/521dce1e-fe6b-4e3f-8e9a-52f17129a591)

- SCV 데이터 파싱
 ```C#
    public void CreateMonster(int StageNum)
    {
        GameObject EnemyPrefab = GameManager.Instance.ObjectPool.SpawnFromPool("Enemy");
        Enemy enemy = EnemyPrefab.GetComponent<Enemy>();

        enemy.Name = elements[StageNum][0];
        enemy.ThisGrade = (Grade)Enum.Parse(typeof(Grade), elements[StageNum][1]);
        enemy.Speed = float.Parse(elements[StageNum][2]);
        enemy.MaxHp = int.Parse(elements[StageNum][3]);
        enemy.transform.position = SpawnLocationTransform.position;
        EnemyPrefab.GetComponentInChildren<Animator>().runtimeAnimatorController = MonsterAnimators[StageNum-1];
        EnemyPrefab.SetActive(true);
    }

    private void ParsingData()
    {
        int count = 0;
        datas = csvData.text.Split(new char[] { '\n' });
        elements = new string[datas.Length][];
        foreach (var data in datas)
        {
            elements[count] = data.Split(new char[] { ',' });
            count++;
        }
    }
```
- ObjectPool을 통한 다량의 오브젝트 활성화/최적화
