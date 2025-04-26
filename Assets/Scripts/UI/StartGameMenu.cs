using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameMenu : MonoBehaviour
{
    public GameObject[] tabs; // Массив панелей для вкладок
    public Button[] tabButtons; // Массив кнопок для вкладок

    private void Start()
    {
        // Скрываем все вкладки, кроме первой
        ShowTab(0);

        // Добавляем обработчики событий для кнопок
        for (int i = 0; i < tabButtons.Length; i++)
        {
            int index = i; // Локальная переменная для замыкания
            tabButtons[i].onClick.AddListener(() => ShowTab(index));
        }
    }
    public void ShowTab(int index)
    {
        // Скрываем все вкладки
        foreach (GameObject tab in tabs)
        {
            tab.SetActive(false);
        }

        // Показываем выбранную вкладку
        if (index >= 0 && index < tabs.Length)
        {
            tabs[index].SetActive(true);
        }
    }
    public void StartGame()
    {
        
    }

    public void OpenInventory()
    {

    }

    public void OpenWorldSettings()
    {

    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}
