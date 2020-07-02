# Click Navigation Project

Unity Version: 2018.4f

## Build

First walk through the presentation that shows off what the project is composed of and what we'll be building.

### Step 1: Building the Prefab

The prefab is going to be an empty GameObject with a parent.

First we just need to build a cube and give it color.

- Create a cube in the hierarchy.

- Create a materials folder.

- Create a material to assign to the cube.

- Make the cube into a prefab.

![Cube Prefab](./Resources/Prefab.png)

### Step 2: Rotate.cs

The first script is simple, a rotation about the y-axis.

- Create a *"Scripts"* folder.

- Write the *"Rotate.cs"* script

Rotate.cs

```csharp
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 1f;

    void Update()
    {
        // Multiply vector (0,1,0) by the speed and deltaTime every frame
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
```

- Attach the script to the cube.

- Press play and manipulate the speed.

![Rotate](./Resources/Rotate.gif)

### Step 3: Creating a Parent

Having a parent with all of the transform scripts gives us more control in the editor.

- Create an empty `GameObject` named *ObjectHolder* in the inspector.

- Parent *Cube* to *ObjectHolder*.

- Delete the *Cube* Prefab and replace it with *ObjectHolder*.

- Delete the *Rotate.cs* script from *Cube* and attach it to *ObjectHolder*.

Now, we can change how the rotation affects the cube by moving it away from the origin.

- Set the cube to local position (0,0,0).

- Press play and show the cube rotate in place.

- Move the cube to local position (3,0,0).

- Set the axes to local in the toolbar.

- Press play and show the cube rotation around its parent in the scene view.

- Move the parent around in the scene to show that the cube always stays with its parent.

![Rotate Parent](./Resources/RotateParent.gif)

### Step 4: GrowShrink.cs

```csharp
using UnityEngine;

public class GrowShrink : MonoBehaviour
{
    public float maxSize = 3f;

    public float minSize = 0.5f;
    public float scaleSpeed = 1f;

    Transform childTransform;

    bool growing = true;

    void Awake()
    {
        // Get a reference to the child transform.
        childTransform = transform.GetChild(0).transform;
    }

    void Start()
    {
        childTransform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the child has passed the maximum distance, if so, change the direction.
        if (childTransform.localScale.x >= maxSize) {
            growing = false;
        } else if (childTransform.localScale.x <= minSize) {
            growing = true;
        }

        // Check which direction the child is moving, then move its position in that direction.
        if (growing) {
            childTransform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        } else {
            childTransform.localPosition -= Vector3.one * scaleSpeed * Time.deltaTime;
        }
    }
}
```

![Grow Shrink](./Resources/GrowShrink.gif)

### Step 5: BackForth.cs

The *BackForth.cs* script will move the object back and forth across the origin. We can accomplish the same oscillating behavior we saw in GrowShrink by representing the motion with a sin wave.

```csharp
using UnityEngine;

public class BackForth : MonoBehaviour
{

    public float moveSpeed = 1f;

    public float maxDistance = 3f;

    private Transform childTransform;

    void Awake()
    {
        // Get a reference to the child's transform
        childTransform = transform.GetChild(0).transform;
    }

    void Start()
    {
        // Start the child object at parent's origin.
        childTransform.localPosition = Vector3.zero;
    }

    void Update()
    {
        // Move the child back and forth.
        childTransform.localPosition = Vector3.right * Mathf.Sin(Time.time * moveSpeed) * maxDistance;
    }
}
```

![BackForth](./Resources/BackForth.gif)

### Step 6: Random Generator
