//*****************************************************************************
//** 1905 Count Sub Islands  leetcode                                        **
//*****************************************************************************


/*
int directions[4][2] = { {0, 1}, {1, 0}, {0, -1}, {-1, 0} };

void dfs(int** grid1, int** grid2, int x, int y, int grid1Size, int grid1ColSize, bool *isSubIsland)
{
    if (x < 0 || x >= grid1Size || y < 0 || y >= grid1ColSize || grid2[x][y] == 0)
    {
        return;
    }

    if (grid1[x][y] == 0)
    {
        *isSubIsland = false;
    }

    grid2[x][y] = 0;

    for (int i = 0; i < 4; i++)
    {
        int newX = x + directions[i][0];
        int newY = y + directions[i][1];
        dfs(grid1, grid2, newX, newY, grid1Size, grid1ColSize, isSubIsland);
    }
}

int countSubIslands(int** grid1, int grid1Size, int* grid1ColSize, int** grid2, int grid2Size, int* grid2ColSize)
{
    int subIslandCount = 0;

    for (int i = 0; i < grid2Size; i++)
    {
        for (int j = 0; j < grid2ColSize[i]; j++)
        {
            if (grid2[i][j] == 1)
            {
                bool isSubIsland = true;
                dfs(grid1, grid2, i, j, grid1Size, grid1ColSize[i], &isSubIsland);

                if (isSubIsland)
                {
                    subIslandCount++;
                }
            }
        }
    }

    return subIslandCount;
}
*/

#define MAX_SIZE 250000  // Maximum possible size for the stack (500 * 500)

int directions[4][2] = { {0, 1}, {1, 0}, {0, -1}, {-1, 0} };

bool dfs(int** grid1, int** grid2, int startX, int startY, int gridSize, int gridColSize)
{
    int stack[MAX_SIZE][2]; // Fixed size for the stack
    int top = -1;
    bool isSubIsland = true;

    // Push the initial coordinates onto the stack
    stack[++top][0] = startX;
    stack[top][1] = startY;

    while (top >= 0)
    {
        int x = stack[top][0];
        int y = stack[top--][1];

        // If out of bounds or already visited, skip
        if (x < 0 || x >= gridSize || y < 0 || y >= gridColSize || grid2[x][y] == 0)
        {
            continue;
        }

        // If the corresponding cell in grid1 is water, it's not a sub-island
        if (grid1[x][y] == 0)
        {
            isSubIsland = false;
        }

        // Mark as visited in grid2
        grid2[x][y] = 0;

        // Push adjacent cells to stack
        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i][0];
            int newY = y + directions[i][1];
            stack[++top][0] = newX;
            stack[top][1] = newY;
        }
    }

    return isSubIsland;
}

int countSubIslands(int** grid1, int grid1Size, int* grid1ColSize, int** grid2, int grid2Size, int* grid2ColSize)
{
    int subIslandCount = 0;

    for (int i = 0; i < grid2Size; i++)
    {
        for (int j = 0; j < grid2ColSize[i]; j++)
        {
            if (grid2[i][j] == 1)
            {
                if (dfs(grid1, grid2, i, j, grid1Size, grid1ColSize[i]))
                {
                    subIslandCount++;
                }
            }
        }
    }

    return subIslandCount;
}

