using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private GameObject subCubePrefab;

    public  int          size { get; private set; } = 3;
    private float        defaultRotationSpeed = 200;
    private CubeRotation cubeRotation;
    private CubeShuffle  cubeShuffle;
    private CubeResolve  cubeResolve;

    private Button          resetButton;
    private Slider          sizeSlider;
    private TextMeshProUGUI sizeValueText;

    void Awake()
    {
        cubeRotation  = gameObject.GetComponent<CubeRotation>();
        cubeResolve   = gameObject.GetComponent<CubeResolve >();
        cubeShuffle   = gameObject.GetComponent<CubeShuffle >();
        resetButton   = GameObject.Find("ResetButton"  ).GetComponent<Button>();
        sizeSlider    = GameObject.Find("SizeSlider"   ).GetComponent<Slider>();
        sizeValueText = GameObject.Find("SizeValueText").GetComponent<TextMeshProUGUI>();

        defaultRotationSpeed = cubeRotation.rotationSpeed;

        resetButton.onClick.AddListener(ResetCube);
        sizeSlider.onValueChanged.AddListener(UpdateCubeSize);

        Create();
    }

    private void UpdateCubeSize(float value)
    {
        sizeValueText.SetText(value.ToString());
        ResetCube();
    }

    private void Create()
    {
        // Create the rubik's cube parent.
        GameObject rubiksCube = new GameObject("Rubik's Cube (" + size.ToString() + "x" + size.ToString() + "x" + size.ToString() + ")");
        rubiksCube.transform.position = new Vector3(0, 0, 0);
        rubiksCube.transform.SetParent(transform, false);

        // Get the rubik's cube size from the size slider.
        size = (int)sizeSlider.value;

        // Compute the offset used to center the cube.
        Vector3 offset = new Vector3(size / 2, size / 2, size / 2);
        if (size % 2 == 0)
            offset -= new Vector3(0.5f, 0.5f, 0.5f);

        // Create all of the sub-cubes.
        for (int z = 0; z < size; ++z) {
            for (int y = 0; y < size; ++y) {
                for (int x = 0; x < size; ++x) {
                    if (!(x == 0 || x == size-1 || y == 0 || y == size-1 || z == 0 || z == size-1))
                        continue;

                    GameObject curSubCube = Instantiate(subCubePrefab, new Vector3(x, y, z), Quaternion.identity);
                    curSubCube.name = "Sub-Cube (" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ")";
                    curSubCube.transform.position -= offset;
                    curSubCube.transform.SetParent(rubiksCube.transform, false);
                }
            }
        }

        // Keep the cube's size consistent.
        transform.localScale = new Vector3(3f / size, 3f / size, 3f / size) * 1000f;
    }

    private void ResetCube()
    {
        // Stop any actions happening on the cube.
        cubeShuffle.StopShuffle();
        cubeResolve.StopResolve();
        cubeResolve.ResetHistory();
        cubeRotation.StopRotation();
        cubeRotation.rotationSpeed = defaultRotationSpeed;

        // Destroy the previous cube and create a new one.
        GameObject.Destroy(transform.GetChild(0).gameObject);
        Create();
    }
}
