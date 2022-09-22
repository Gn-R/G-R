using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_inge : MonoBehaviour
{

    Ray camRay;
    RaycastHit hitInfo;
    public float x;
    public float y;
    public float z;
    private Vector3 direction;
    private Vector3 bowlPos;
    private Vector3 offset;
    private Vector3 randomPosition;

    public GameObject pointpos;
    public Canvas UI;
    public GameObject[] inge;
    public GameObject[] pointtype;

    public AudioSource Add;
    public AudioSource Mix;

    public GameObject manager;
    public GameObject rails;

    public Transform ingredientParent;

    private void Start()
    {
        bowlPos = transform.position;
        offset = new Vector3(0, 1, 0);
       // offsetmore = new Vector3(0, 2, 0);
        //offsetp = new Vector3(1, 0, 0);
        Manager.Instance.combo = new List<string>();

        //var randomPosition = Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z) );

        randomPosition = new Vector3(0, 1, 0);

        Add.GetComponents<AudioSource>();
        Mix.GetComponents<AudioSource>();

    }
    void Update()
    {
        bowlPos = transform.position;
        if (Manager.Instance.Mixing == false && Manager.Instance.discarding == false)
        {
            camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(camRay.origin, camRay.direction * 100, Color.red);

            x = Input.mousePosition.x;

            y = Input.mousePosition.y;

            z = Input.mousePosition.z;

            direction = new Vector3(x, y, z);

            //else if (hitInfo.transform.name == "Well5" | hitInfo.transform.name == "ing3")
            //{
            //    if (Input.GetMouseButtonDown(0))
            //    {
            //        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
            //        Instantiate(inge[2], bowlPos + offset, Quaternion.Euler(0, 0, 0));
            //        Instantiate(pointtype[0], pointpos[2].transform.position, Quaternion.Euler(0, 0, 0), UI.transform);
            //        Manager.Instance.Score += 10;
            //        Manager.Instance.combo.Add("Blue ");
            //        Add.Play();
            //    }

            if (Physics.Raycast(camRay, out hitInfo, float.MaxValue))
            {
                Transform railPoint = rails.GetComponent<LerpRail>().points[rails.GetComponent<LerpRail>().currPoint].GetChild(1);

                Vector3 randomVector = getRandomOffset();
                if (hitInfo.transform.name == "Brown")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        for (int i = 0; i < 5; i++)
                        {
                            Instantiate(inge[0], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                            randomVector = getRandomOffset();
                        }
                        Instantiate(pointtype[0], railPoint.transform.position , railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Brown Rice");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Brown Rice"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Brown Rice"));
                        }
                    }

                }
                else if (hitInfo.transform.name == "Roots")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        for (int i = 0; i < 5; i++)
                        {
                            Instantiate(inge[1], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                            randomVector = getRandomOffset();
                        }
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Roots Rice");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Roots Rice"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Roots Rice"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Chickp")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[2], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Chickpeas");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Chickp"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Chickp"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Broccoli")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[3], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Broccoli");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Broccoli"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Broccoli"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Cannellinib")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[4], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Cannelini Beans");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Cannelini Beans"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Cannelini Beans"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Beets")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[5], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Roasted Beets");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Roasted Beets"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Roasted Beets"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Sweetp")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[6], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Sweet Potatoes");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Sweeet Potatoes"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Sweet Potatoes"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Blackb")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[7], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Black Beans");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Black Beans"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Black Beans"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Bulgar")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[8], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Bulgur");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Bulgur"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Bulgur"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Corn")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[9], bowlPos + offset + randomVector, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Charred Corn");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Charred Corn"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Charred Corn"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Cucumber")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[10], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Cucumbers");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Cucumber"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Cucumber"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Onion")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[11], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Red Onions");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Red Onions"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Red Onions"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Tomatoes")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[12], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Grape Tomatoes");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Grape Tomatoes"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Grape Tomatoes"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Feta")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[13], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Feta");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Feta"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Feta"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Parmesan")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[14], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Shaved Parmesan");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Parmesan"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Parmesan"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Avocado")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[15], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Avocado");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Avocado"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Avocado"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Chips")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[16], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Pita Chips");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Chips"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Chips"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Lime")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[17], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Cilantro Lime");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Cilantro Lime"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Cilantro Lime"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Egg")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[18], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Hard Boiled Egg");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Hard Boiled Egg"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Hard Boiled Egg"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Cheddar")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[19], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Cheddar");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Cheddar"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Cheddar"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Pickled_o")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position+-, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[20], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Lime-Pickled Onions");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Lime-Pickled Onions"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Lime-Pickled Onions"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Jalapeno")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[21], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Pickled Jalapenos");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Pickled Jalapenos"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Pickled Jalapenos"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Red_Cab")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[22], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Red Cabbage");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Red Cabbage"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Red Cabbage"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Goat")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[23], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Goat Cheese");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Goat Cheese"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Goat Cheese"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Pine")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[24], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Pineapple");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Pineapple"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Pineapple"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Carrots")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[25], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Carrots");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Carrots"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Carrots"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Tofu")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[26], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Tofu");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Tofu"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Tofu"));
                        }
                    }
                }
                else if (hitInfo.transform.name == "Chicken")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[27], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
                        Instantiate(pointtype[0], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                        Manager.Instance.Score += 10;
                        Manager.Instance.combo.Add("Chicken");
                        Add.Play();

                        if (manager.GetComponent<DishManager>().requiresExtra("Chicken"))
                        {
                            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar("Chicken"));
                        }
                    }
                }


















                else if (hitInfo.transform.name == "MainBowl")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Manager.Instance.Mixing == false)
                        {
                            Instantiate(pointtype[1], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
                            //Manager.Instance.Score += 100;
                            manager.GetComponent<DishManager>().mixBowl(false);
                            manager.GetComponent<LerpRail>().advanceStopPoint();

                            if (manager.GetComponent<DishManager>().checkMix(Manager.Instance.combo))
                            {
                                Manager.Instance.Score += 100;
                            }
                            else
                            {
                                Manager.Instance.Score -= 100;
                            }
                        }
                        Manager.Instance.Mixing = true;
                        Mix.Play();
                    }

                }
            }
        }
    }

    //Used to offset ingredients to instantiate into bowl
    private Vector3 getRandomOffset() => new Vector3(Random.Range(-0.09f, 0.1f), Random.Range(-0.2f, 0.2f), Random.Range(-0.175f, 0.05f));
}




//if (Manager.Instance.IsLaunched == false)
//{
//    //screenray = Camera.main.ScreenPointToRay(Input.mousePosition);

//    x = UltimateJoystick.GetHorizontalAxis("Joy");

//    z = UltimateJoystick.GetVerticalAxis("Joy");

//    //Debug.DrawRay(screenray.origin, screenray.direction * 100, Color.red);

//    //if (Physics.Raycast(screenray, out hitInfo, float.MaxValue))
//    //{

//    //if (hitInfo.transform.name == "Plane")
//    //{
//    Direction = new Vector3(x, 0, z) * 100f;
//    //Debug.Log(Direction);
//    if (Direction.magnitude > 0.5)
//    {
//        Manager.Instance.Direction = Direction;
//        Manager.Instance.UIPoint = Direction;
//    }
//    //}
//    //}

//    //Debug.DrawRay(shiporigin, directions * 100, Color.yellow);
//    Manager.Instance.ShipPos = ShipOrigin;