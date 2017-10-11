using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class MediaPlayerUI : MonoBehaviour
{
	public float maxTime;

	public Text timeText;

	public Button stepBackButton;
	public Button pauseButton;
	public Button stepForwardButton;
	public Slider slider;

	[SerializeField]
	private bool play = true;

	void Start()
	{
		slider.minValue = 0f;
		slider.maxValue = maxTime;

		stepBackButton.onClick.AddListener(StepBack);
		pauseButton.onClick.AddListener(PausePlay);
		stepForwardButton.onClick.AddListener(StepForward);
	}

	void Update()
	{
		if (play) {
			slider.value += Time.deltaTime;
		}
		if (timeText != null) {
			timeText.text = string.Format("{0:F2}", slider.value);
		}
	}
	
	private void StepBack() {
		slider.value -= Time.deltaTime;
	}

	private void PausePlay() {
		play = !play;
	}

	private void StepForward() {
		slider.value += Time.deltaTime;
	}

	public float CurrentTime {
		get {
			return slider.value;
		}
	}
}
